using Business.Facede;
using Business.Facede.Command;
using Business.Facede.Models;
using Business.Facede.Query;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Api.Controllers
{
    public class UploadPhotoController : ApiController
    {
        private readonly ICommandHandler<Student> updateImageUrlCommandHandler;

        public UploadPhotoController()
        {
            updateImageUrlCommandHandler = new UpdateImageUrlCommandHandler();
        }
        public async Task<HttpResponseMessage> Post()
        {
            var id = Request.Headers.GetValues("studentId").FirstOrDefault();
            var name = Request.Headers.GetValues("studentName").FirstOrDefault();
            // Check if the request contains multipart/form-data.
            if (Request.Content.IsMimeMultipartContent())
            {

                var streamProvider = new MultipartMemoryStreamProvider();
                streamProvider = await Request.Content.ReadAsMultipartAsync(streamProvider);
                
                foreach (var item in streamProvider.Contents)//.Where(c => !string.IsNullOrEmpty(c.Headers.ContentDisposition.FileName)))
                {
                    MemoryStream ms = new MemoryStream(await item.ReadAsByteArrayAsync());
                    string path = HttpContext.Current.Server.MapPath("~/photos/diploma");
                    var fileName = item.Headers.ContentDisposition.FileName.Replace("\"", string.Empty).Trim();
                    var extension = fileName.Split('.').LastOrDefault();
                    fileName = name + "--" + id + "." + extension;
                    FileStream file = new FileStream(path + "\\" + fileName, FileMode.Create, FileAccess.Write);
                    ms.WriteTo(file);
                    file.Close();
                    ms.Close();
                    int studentId;
                    int.TryParse(id, out studentId);
                    updateImageUrlCommandHandler.Execute(new Student {
                        Id = studentId,
                        ImageUrl = "/photos/diploma/" + fileName
                    });
                }

            }
            return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Student registration successful. Please note down student id generated is: " + id , Id = id});
            //return Request.CreateResponse(HttpStatusCode.OK, new { message = name+ ", " + id});
        }

        public string Get() {
            string path = HttpContext.Current.Server.MapPath("~/photos/diploma");
            var y = new GetStudentIdQuery();
            var c = y.QueryAll();
            return c;
        }

    }
}
