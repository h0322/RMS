using HH.ProjectMovie.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.ProjectMovie.Service.Interface
{
    public interface IVideoService
    {
        VideoPullModel GetVideoInfoByName(string name);
    }
}
