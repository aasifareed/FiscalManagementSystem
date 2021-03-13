using Abp.Auditing;
using Abp.EntityFrameworkCore;
using Abp.IO.Extensions;
using Abp.Timing;
using Abp.Timing.Timezone;
using Abp.UI;
using Abp.Web.Models;
using FiscalManagementSystem.Configuration;
using FiscalManagementSystem.EntityFrameworkCore;
using FiscalManagementSystem.ProductCatagoriesPictures;
using FiscalManagementSystem.ProductPictures;
using FiscalManagementSystem.Storage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FiscalManagementSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    public class FileController: FiscalManagementSystemControllerBase
    {
        private readonly IDbContextProvider<FiscalManagementSystemDbContext> _dbContextProvider;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public FileController(
            IWebHostEnvironment hostingEnvironment,
            IDbContextProvider<FiscalManagementSystemDbContext> dbContextProvider
            )
		{
       _hostingEnvironment = hostingEnvironment;
            _dbContextProvider = dbContextProvider;
        }

        private FiscalManagementSystemDbContext Context => _dbContextProvider.GetDbContext();



        //[DisableAuditing]
        //public ActionResult DownloadTempFile(FileDto file)
        //{
        //	var fileBytes = _tempFileCacheManager.GetFile(file.FileToken);
        //	if (fileBytes == null) return NotFound(L("RequestedFileDoesNotExists"));

        //	return File(fileBytes, file.FileType, file.FileName);
        //}

        //[DisableAuditing]
        //public async Task<ActionResult> DownloadBinaryFile(Guid id, string contentType, string fileName)
        //{
        //	var fileObject = await _binaryObjectManager.GetOrNullAsync(id);
        //	if (fileObject == null) return StatusCode((int)HttpStatusCode.NotFound);

        //	return File(fileObject.Bytes, contentType, fileName);
        //}

        //public async Task<JsonResult> DeleteTicketFile()
        //{
        //	var fileId = Request.Form["fileId"].ToString();
        //	if (fileId != null)
        //	{
        //		var ticketFile = await Context.TicketFiles.FindAsync(Convert.ToInt32(fileId));
        //		if (ticketFile != null)
        //		{
        //			var sPrefix = ticketFile.TicketId.ToString()
        //				.Substring(0, ticketFile.TicketId.ToString().Length - 4);
        //			var sBeginNumber = sPrefix + "0000";
        //			var sEndNumber = sPrefix + "9999";

        //			var rootPath = GetFileRootPath();

        //			var attachmentsRootPath = Path.Combine(rootPath,
        //				"Attachments/TicketFiles/" + "Tickets_" + sBeginNumber + "_" + sEndNumber + @"\" +
        //				ticketFile.TicketId);
        //			var fileName = attachmentsRootPath + "/" + ticketFile.FileName;

        //			fileName = Path.GetFullPath(fileName);

        //			var fi = new FileInfo(fileName);
        //			// Using the FileInfo as the File.Exists will not work on the Network Paths
        //			if (fi.Exists) System.IO.File.Delete(fileName);

        //			Context.TicketFiles.Remove(ticketFile);
        //			var result = await Context.SaveChangesAsync();

        //			if (result == 1) return Json(new AjaxResponse(true));
        //		}
        //	}

        //	return Json(new AjaxResponse(false));
        //}

        [HttpPost]
        public JsonResult UploadProductFiles()
        {
            try
            {
                
                var files = Request.Form.Files;
                var fileName = Request.Form["FileName"].ToString();
                var ProductId = Request.Form["ProductId"].ToString();

                if (files == null)
                {
                    throw new UserFriendlyException(L("File_Empty_Error"));
                }

                
                foreach (var file in files)
                {
                    
                          var ms = new MemoryStream();
                        
                            file.CopyTo(ms);
                            var fileBytes = ms.ToArray();
                          
                            // act on the Base64 data
                            ProductPicture productPicture = new ProductPicture
                            {
                                ProductId = Convert.ToInt32(ProductId),
                                Name = fileName,
                                file = fileBytes,
                            };

                            Context.ProductPictures.Add(productPicture);
                            Context.SaveChanges();
                        


                }
             
                return Json(new AjaxResponse("Success"));
            }
            catch (UserFriendlyException ex)
            {
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }

        }

        [HttpPost]
        public JsonResult UploadProductCatagoryFiles()
        {
            try
            {
                var files = Request.Form.Files;
                var fileName = Request.Form["FileName"].ToString();
                var ProductCatagoryId = Request.Form["ProductCatagoryId"].ToString();

                if (files == null)
                {
                    throw new UserFriendlyException(L("File_Empty_Error"));
                }

                foreach (var file in files)
                {

                    var ms = new MemoryStream();

                    file.CopyTo(ms);
                    var fileBytes = ms.ToArray();

                    // act on the Base64 data
                    ProductCatagoryPictures productPicture = new ProductCatagoryPictures
                    {
                        ProductCatagoryId = Convert.ToInt32(ProductCatagoryId),
                        Name = fileName,
                        file = fileBytes,
                    };

                    Context.ProductCatagoryPictures.Add(productPicture);
                    Context.SaveChanges();

                }

                return Json(new AjaxResponse("Success"));
            }
            catch (UserFriendlyException ex)
            {
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }

        }


    }
}
