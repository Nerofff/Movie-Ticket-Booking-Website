﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploadControl
{
    public interface UploadInterface
    {
        void uploadfilemultiple(IList<IFormFile> files);
      
    }
}
