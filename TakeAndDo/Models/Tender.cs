using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TakeAndDo.Models
{
    public class Tender
    {
        public int ID { get; set; }
        [StringLength(255)]
        public string Credits { get; set; }
        [StringLength(255)]
        public string Link { get; set; }

        public int TenderTypeId { get; set; }
        public TenderType TenderType { get; set; }

        public int? StockId { get; set; }
        public Stock Stock { get; set; }

        public int? RegionId { get; set; }
        public Region Region { get; set; }

        public int? TenderCategoryId { get; set; }
        public TenderCategory TenderCategory { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        // дата окончания подачи заявок
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ExpirationDate { get; set; }

        // дата участия
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ParticipationDate { get; set; }

        // срок поставки
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CompletionDate { get; set; }

        // НМЦК
        public decimal? InitMaxContractPrice { get; set; }

        // МРЦ
        public decimal? MinEstimatedPrice { get; set; }

        // цена с НДС
        public decimal? VatIncludePrice { get; set; }

        // цена с доставкой
        public decimal? DeliveryPrice { get; set; }

        // наценка
        public decimal? ExtraCharge { get; set; }

        public Tender()
        {
            Orders = new List<Order>();
        }
    }
}