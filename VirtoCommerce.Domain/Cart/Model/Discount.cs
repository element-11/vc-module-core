﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Platform.Core.Common;


namespace VirtoCommerce.Domain.Cart.Model
{
	public class Discount : Entity
	{
		public string PromotionId { get; set; }
		public string Currency { get; set; }
		public virtual decimal DiscountAmount { get; set; }
        private decimal? _discountAmountWithTax;

        public virtual decimal DiscountAmountWithTax
        {
            get
            {
                return _discountAmountWithTax ?? DiscountAmount;
            }
            set
            {
                _discountAmountWithTax = value;
            }
        }
        public string Coupon { get; set; }
		public string Description { get; set; }
	}
}
