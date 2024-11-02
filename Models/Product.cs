using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Globalization;


namespace OnlineShop.Models
{
    public class Product
    {
        public int Id { get; set; }

        [StringLength(200, ErrorMessage = "بین 1 تا 200 حروف استفاده کنید.")]
        [Required(ErrorMessage = "نام کالا را وارد کنید.")]
        public string Name { get; set; } = String.Empty;

        public string? Image {  get; set; }
        public string Description { get; set; } = String.Empty;

        [RegularExpression(@"^\d+$", ErrorMessage = "لطفاً یک عدد صحیح وارد کنید.")]
        [Required(ErrorMessage = "قیمت را وارد کنید.")]
        [Range(1, 1000000000, ErrorMessage = "قیمیت باید بین 1 هزار تومان تا 1 میلیارد تومان باشد.")]
        public int Price { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "لطفاً یک عدد صحیح وارد کنید.")]
        [Required(ErrorMessage = "موجودی را وارد کنید.")]
        [Range(1, 100, ErrorMessage = "موجودی باید بین 1 تا 100 باشد.")]
        public int Stock { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string PersianCreatedDate
        {
            get
            {
                var persianCalendar = new PersianCalendar();
                int year = persianCalendar.GetYear(CreatedDate);
                int month = persianCalendar.GetMonth(CreatedDate);
                int day = persianCalendar.GetDayOfMonth(CreatedDate);
                string time = CreatedDate.ToString("HH:mm");

                return $"{year:0000}/{month:00}/{day:00} {time}";
            }
        }
    }
}
