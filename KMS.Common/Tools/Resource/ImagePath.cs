using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 using Microsoft.Extensions.Configuration;


namespace KMS.Common.Tools.Resource;

using Microsoft.Extensions.Configuration;

public static class ImagePath
{
    public static string GetUserAvatarPath(IConfiguration config, string imageName)
    {
        if (config == null)  throw new ArgumentNullException(nameof(config));
 
        return (imageName == string.Empty || imageName == null) ? string.Empty : config["UserAvatar"] + imageName;
    }
}

