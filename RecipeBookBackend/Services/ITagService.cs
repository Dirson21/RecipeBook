﻿using Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ITagService
    {
        List<TagDto> getTags();

        TagDto getTagByName(string name);



    }
}
