﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Domain.Catalog.Model;
using VirtoCommerce.Domain.Commerce.Model;
using VirtoCommerce.Domain.Pricing.Model;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.DynamicProperties;

namespace VirtoCommerce.Domain.Cart.Model
{
    public class LineItem : AuditableEntity, IHaveTaxDetalization, IHasDynamicProperties
	{
		public string ProductId { get; set; }
		public CatalogProduct Product { get; set; }
		public string CatalogId { get; set; }
		public string CategoryId { get; set; }
		public string Sku { get; set; }
        public string ProductType { get; set; }

		public string Name { get; set; }
		public int Quantity { get; set; }

		public string FulfillmentLocationCode { get; set; }
		public string ShipmentMethodCode { get; set; }
		public bool RequiredShipping { get; set; }
		public string ThumbnailImageUrl { get; set; }
		public string ImageUrl { get; set; }

		public bool IsGift { get; set; }
		public string Currency { get; set; }

		public string LanguageCode { get; set; }

		public string Note { get; set; }

		public bool IsReccuring { get; set; }

		public string TaxType { get; set; }
		public bool TaxIncluded { get; set; }

		public decimal? VolumetricWeight { get; set; }


		public string WeightUnit { get; set; }
		public decimal? Weight { get; set; }

		public string MeasureUnit { get; set; }
		public decimal? Height { get; set; }
		public decimal? Length { get; set; }
		public decimal? Width { get; set; }

        /// <summary>
        /// Represent any line item validation type (noPriceValidate, noQuantityValidate etc) this value can be used in storefront 
        /// to select appropriate validation strategy
        /// </summary>
        public string ValidationType { get; set; }

        public string PriceId { get; set; }
        public Price Price { get; set; }

        /// <summary>
        /// old price for one unit
        /// </summary>
        public virtual decimal ListPrice { get; set; }

        private decimal? _listPriceWithTax;
        public virtual decimal ListPriceWithTax
        {
            get
            {
                return _listPriceWithTax ?? ListPrice;
            }
            set
            {
                _listPriceWithTax = value;
            }
        }

        private decimal? _salePrice;
        /// <summary>
        /// new price for one unit
        /// </summary>
		public virtual decimal SalePrice
        {
            get
            {
                return _salePrice ?? ListPrice;
            }
            set
            {
                _salePrice = value;
            }
        }

        private decimal? _salePriceWithTax;
        public virtual decimal SalePriceWithTax
        {
            get
            {
                return _salePriceWithTax ?? SalePrice;
            }
            set
            {
                _salePriceWithTax = value;
            }
        }

        /// <summary>
        /// Resulting price with discount for one unit
        /// </summary>
		public virtual decimal PlacedPrice
        {
            get
            {
                return ListPrice - DiscountAmount;
            }
        }
        public virtual decimal PlacedPriceWithTax
        {
            get
            {
                return ListPriceWithTax - DiscountAmountWithTax;
            }
        }


        public virtual decimal ExtendedPrice
        {
            get
            {
                return PlacedPrice * Quantity;
            }
        }

        public virtual decimal ExtendedPriceWithTax
        {
            get
            {
                return PlacedPriceWithTax * Quantity;
            }
        }

        /// <summary>
        /// Gets the value of the single qty line item discount amount
        /// </summary>
        private decimal? _discountAmount;
        public virtual decimal DiscountAmount
        {
            get
            {
                var retVal = _discountAmount;
                if (retVal == null)
                {
                    retVal = ListPrice -  SalePrice;                
                }
                return retVal.Value;
            }
            set
            {
                _discountAmount = value;
            }
        }

        private decimal? _discountAmountWithTax;
        public virtual decimal DiscountAmountWithTax
        {
            get
            {
                var retVal = _discountAmountWithTax;
                if (retVal == null)
                {
                    retVal = ListPriceWithTax - SalePriceWithTax;                 
                }
                return retVal.Value;
            }
            set
            {
                _discountAmountWithTax = value;
            }
        }

        private decimal? _discountTotal;
        public virtual decimal DiscountTotal
        {
            get
            {
                var retVal = _discountTotal;
                if(retVal == null)
                {
                    retVal = DiscountAmount * Quantity;
                }
                return retVal.Value;
            }
            set
            {
                _discountTotal = value;
            }
        }

        private decimal? _discountTotalWithTax;
        public virtual decimal DiscountTotalWithTax
        {
            get
            {
                var retVal = _discountTotalWithTax;
                if (retVal == null)
                {
                    retVal = DiscountAmountWithTax * Quantity;
                }
                return retVal.Value;
            }
            set
            {
                _discountTotalWithTax = value;
            }
        }

        private decimal? _taxTotal;
        public virtual decimal TaxTotal
        {
            get
            {
                var retVal = _taxTotal;
                if (retVal == null)
                {
                    retVal = Math.Abs(ExtendedPriceWithTax - ExtendedPrice);
                }
                return retVal.Value;
            }
            set
            {
                _taxTotal = value;
            }
        }

        public ICollection<Discount> Discounts { get; set; }

		#region IHaveTaxDetalization Members
		public ICollection<TaxDetail> TaxDetails { get; set; }
		#endregion

        #region IHasDynamicProperties Members
        public string ObjectType { get; set; }
        public ICollection<DynamicObjectProperty> DynamicProperties { get; set; }

        #endregion
	}
}
