using System;

namespace Hua.Huixuan.Business
{
    public class CarWashInvoice : Invoice
    {
        private decimal packageCost;
        private decimal fragranceCost;

        /// <summary>
        /// Gets and sets the amount charged for the chosen package.
        /// </summary>
        /// <exception cref="System.ArgumentOutOfRangeException">When the property is set to less than 0.</exception>
        public decimal PackageCost
        {
            get
            {
                return packageCost;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value",
                        "The value cannot be less than 0.");
                }

                packageCost = value;
            }
        }

        /// <summary>
        /// Gets and sets the amount charged for the chosen fragrance.
        /// </summary>
        /// <exception cref="System.ArgumentOutOfRangeException">When the property is set to less than 0.</exception>
        public decimal FragranceCost
        {
            get
            {
                return fragranceCost;
            }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentOutOfRangeException("value",
                        "The value cannot be less than 0.");
                }
                
                fragranceCost = value;
            }
        }

        /// <summary>
        /// Gets the amount of provincial sales tax charged to the customer. 
        /// </summary>
        public override decimal ProvincialSalesTaxCharged
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets the amount of goods and services tax charged to the customer.
        /// </summary>
        public override decimal GoodsAndServicesTaxCharged
        {
            get
            {
                return (fragranceCost + packageCost) * GoodsAndServicesTaxRate;
            }
        }

        /// <summary>
        /// Gets the subtotal of the Invoice.
        /// </summary>
        public override decimal SubTotal
        {
            get
            {
                return fragranceCost + packageCost;
            }
        }

        /// <summary>
        /// Initializes an instance of CarWashInvoice with a provincial and goods and services tax rates. The package cost and fragrance cost are zero.
        /// </summary>
        /// <param name="provincialSalesTaxRate">The rate of provincial tax charged to a customer.</param>
        /// <param name="goodsAndServicesTaxRate">The rate of goods and services tax charged to a customer.</param>
        /// <exception cref="System.ArgumentOutOfRangeException"> When the property is set to less than 0.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">When the property is set to greater than 1.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">When the property is set to less than 0.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">When the property is set to greater than 1.</exception>
        public CarWashInvoice(decimal provincialSalesTaxRate, decimal goodsAndServicesTaxRate)
            :this(provincialSalesTaxRate, goodsAndServicesTaxRate, 0, 0)
        { 
        }

        /// <summary>
        /// Initializes an instance of CarWashInvoice with a provincial and goods, services tax rate, package cost and fragrance cost.
        /// </summary>
        /// <param name="provincialSalesTaxRate">The rate of provincial tax charged to a customer.</param>
        /// <param name="goodsAndServicesTaxRate">The rate of goods and services tax charged to a customer.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Throw when the property is set to less than 0.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">When the property is set to greater than 1.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">When the property is set to less than 0.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">When the property is set to greater than 1.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">When the package cost is less than 0.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">When the fragrance cost is less than 0.</exception>
        public CarWashInvoice(decimal provincialSalesTaxRate, decimal goodsAndServicesTaxRate, decimal packageCost, decimal fragranceCost)
            : base(provincialSalesTaxRate, goodsAndServicesTaxRate)
        {
            if (packageCost < 0)
            {
                throw new ArgumentOutOfRangeException("packageCost",
                    "The value cannot be less than 0.");
            }
            if (fragranceCost < 0)
            {
                throw new ArgumentOutOfRangeException("fragranceCost",
                    "The value cannot be less than 0.");
            }

            this.packageCost = packageCost;
            this.fragranceCost = fragranceCost;
        }
    }
}