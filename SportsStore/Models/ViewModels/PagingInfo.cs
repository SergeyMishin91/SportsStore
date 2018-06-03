using System;

namespace SportsStore.Models.ViewModels
{
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }

        //Ceiling - Возвращает наименьшее целое число, 
        //которое больше или равно заданному числу с плавающей 
        //запятой двойной точности. (Floor - наоборот)
        public int TotalPages =>
        (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
    }
}
