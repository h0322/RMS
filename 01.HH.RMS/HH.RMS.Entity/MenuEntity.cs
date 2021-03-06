﻿using HH.RMS.Common.Attributes;
using HH.RMS.Common.Constant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Entity
{
    [MappingTable(tableName = "SystemMenu")]
    public class MenuEntity:EntityBase
    {
        public string code { get; set; }
        [MaxLength(50)]
        public string menuName { get; set; }
        [MaxLength(100)]
        public string description { get; set; }
        public long parentId { get; set; }
        public int menuOrder { get; set; }
        public MenuType menuType { get; set; }
        [MaxLength(100)]
        public string url { get; set; }
        public int treeLevel { get; set; }
        public long selectBitMap { get; set; }
        public long deleteBitMap { get; set; }
        public long insertBitMap { get; set; }
        public long updateBitMap { get; set; }
    }
}
