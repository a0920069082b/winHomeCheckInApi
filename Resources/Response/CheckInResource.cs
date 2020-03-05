using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resources.Response
{
    public class CheckInResource
    {
        #region 資料欄位
        [Required(ErrorMessage = "Title is required.")]
        public string ClientIP { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string ServerIP { get; set; }
        #endregion
    }
}