using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FruitStand.Models
{
    public class FruitStandBindingModel
    {

        private DateTime _saleDate;

        public int Id { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string Fruit { get; set; }

        [Required]
        public DateTime SaleDate
        {
            get
            {
                return _saleDate.AddDays(1);
            }
            set { _saleDate = value; }
        }

        [Required]
        public decimal Price { get; set; }
    }

    public class FruitStandFilterBindingModel
    {
        private DateTime _startDate;
        private DateTime _endDate;

        [Required]
        public DateTime StartDate
        {
            get
            {

                return _startDate.AddDays(1);

            }
            set
            {
                _startDate = value;
            }
        }

        [Required]
        public DateTime EndDate
        {
            get
            {

                return _endDate.AddDays(1);

            }
            set
            {
                _endDate = value;
            }
        }

    }

    public class FruitStandViewModel
    {

        public int Id { get; set; }
        public int Quantity { get; set; }
        public string Fruit { get; set; }
        public string saleDate { get; set; }
        public decimal Price { get; set; }
    }
}