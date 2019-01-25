using System;

namespace Hua.Huixuan.Business
{
    public class ServiceInvoice : Invoice
    {
        /// <summary>
        /// Gets the amount charged for labour.
        /// </summary>
        public decimal LabourCost
        {
            get; private set;
        }

        /// <summary>
        /// Gets the amount charged for parts.
        /// </summary>
        public decimal PartsCost
        {
            get; private set;
        }

        /// <summary>
        /// Gets the amount charged for shop materials.
        /// </summary>
        public decimal MaterialCost
        {
            get; private set;
        }

        /// <summary>
        /// Gets the amount of provincial sales tax charged to the customer.
        /// </summary>
        public override decimal ProvincialSalesTaxCharged
        {
            get
            {
                return (PartsCost + MaterialCost) * ProvincialSalesTaxRate;
            }
        }

        /// <summary>
        /// Gets the amount of goods and services tax charged to the customer.
        /// </summary>
        public override decimal GoodsAndServicesTaxCharged
        {
            get
            {
                return (PartsCost + MaterialCost + LabourCost) * GoodsAndServicesTaxRate;
            }
        }

        /// <summary>
        /// Gets the subtotal of the Invoice.
        /// </summary>
        public override decimal SubTotal
        {
            get
            {
                return PartsCost + MaterialCost + LabourCost;
            }
        }

        /// <summary>
        /// Initializes an instance of ServiceInvoice with a provincial and goods and services tax rates.
        /// </summary>
        /// <param name="provincialSalesTaxRate">The rate of provincial tax charged to a customer.</param>
        /// <param name="goodsAndServicesTaxRate">The rate of goods and services tax charged to a customer.</param>
        /// <exception cref="System.ArgumentOutOfRangeException"> When the property is set to less than 0.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">When the property is set to greater than 1.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">When the property is set to less than 0.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">When the property is set to greater than 1.</exception>
        public ServiceInvoice(decimal provincialSalesTaxRate, decimal goodsAndServicesTaxRate)
            : base(provincialSalesTaxRate, goodsAndServicesTaxRate)
        {
        }

        /// <summary>
        /// Increments a specified cost by the specified amount.
        /// </summary>
        /// <param name="costType">The type of cost being incremented.</param>
        /// <param name="amount">The amount the cost is being incremented by.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">When the amount is less than or equal to 0. </exception>
        public void AddCost(CostType costType, decimal amount)
        {
            if(amount <= 0)
            {
                throw new ArgumentOutOfRangeException("amount",
                    "The argument cannot be less than or equal to 0.");
            }

            switch(costType)
            {
                case CostType.Labour:
                    LabourCost += amount;
                    break;
                case CostType.Material:
                    MaterialCost += amount;
                    break;
                case CostType.Part:
                    PartsCost += amount;
                    break;
            }
        }
    }
}