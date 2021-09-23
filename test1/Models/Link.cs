﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace test1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;  // thêm thư viện định nghĩa chú thích cho các trường thuộc tính 
    
    public partial class Link
    {
        public int LinkID { get; set; }

        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Không đúng định dạng mail")]  // có thể thêm biểu thức expresion để kiểm tra giá trị nhập vào
        [Display(Name ="Tên liên kết")]
        public string LinkName { get; set; }

        [Display(Name = "Mô tả link")]
        public string LinkDescription { get; set; }


        // https://comdy.vn/asp-net-mvc/validation-trong-asp-net-mvc/
        [Range(1,10,ErrorMessage ="Trường này phải nằm trong vùng giá trị từ 1 đến 10")]   
        [Required(ErrorMessage ="ID danh mục không được để trống")]
        [Display(Name = "Id danh mục")]    // thêm required chỉ định thuộc tính là bắt buộc : 
        public Nullable<int> CategoryID { get; set; }
        public string CategoryName { get; set; } // chưa tạo liên kết trong database, nên cần thêm ở đây

    }
}