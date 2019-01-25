using System;

namespace Hua.Huixuan.Business
{
    /// <summary>
    /// This class contains functionality that supports the business process of determining a quote price for a vehicle sale.
    /// </summary>
    public class SalesQuote
    {
        private decimal vehicleSalePrice;
        private decimal tradeInAmount;
        private decimal salesTaxRate;
        private Accessories accessoriesChosen;
        private ExteriorFinish exteriorFinishChosen;

        /// <summary>
        /// Initializes an instance of SalesQuote with a vehicle price, trade-in value, sales tax rate, accessories chosen and exterior finish chosen.
        /// </summary>
        /// <param name="vehicleSalePrice">The selling price of the vehicle being sold.</param>
        /// <param name="tradeInAmount">The amount offered to the customer for the trade in of their vehicle.</param>
        /// <param name="salesTaxRate">The tax rate applied to the sale of a vehicle.</param>
        /// <param name="accessoriesChosen">The value of the chosen accessories.</param>
        /// <param name="exteriorFinishChosen">The value of the chosen exterior finish.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the vehicle sale price is less than or equal to 0.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the trade in amount is less than 0.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the sales tax rate is less than 0.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the sales tax rate is greater than 1.</exception>
        public SalesQuote(decimal vehicleSalePrice, decimal tradeInAmount,
            decimal salesTaxRate, Accessories accessoriesChosen, ExteriorFinish exteriorFinishChosen)
        { 
            if(vehicleSalePrice <= 0)
            {
                throw new ArgumentOutOfRangeException("vehicleSalePrice",
                    "The argument cannot be less than or equal to 0.");
            }

            if (tradeInAmount < 0)
            {
                throw new ArgumentOutOfRangeException("tradeInAmount",
                    "The argument cannot be less than 0.");
            }

            if (salesTaxRate < 0)
            {
                throw new ArgumentOutOfRangeException("salesTaxRate",
                    "The argument cannot be less than 0.");
            }

            if (salesTaxRate > 1)
            {
                throw new ArgumentOutOfRangeException("salesTaxRate",
                    "The argument cannot be greater than 1.");
            }

            this.vehicleSalePrice = vehicleSalePrice;
            this.tradeInAmount = tradeInAmount;
            this.salesTaxRate = salesTaxRate;
            this.accessoriesChosen = accessoriesChosen;
            this.exteriorFinishChosen = exteriorFinishChosen;
        }

        /// <summary>
        /// Initializes an instance of SalesQuote with a vehicle price, trade-in amount, sales tax rate, no accessories chosen and no exterior finish chosen.
        /// </summary>
        /// <param name="vehicleSalePrice">The selling price of the vehicle being sold.</param>
        /// <param name="tradeInAmount">The amount offered to the customer for the trade in of their vehicle.</param>
        /// <param name="salesTaxRate">The tax rate applied to the sale of a vehicle.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the vehicle sale price is less than or equal to 0.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the trade in amount is less than 0.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the sales tax rate is less than 0.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the sales tax rate is greater than 1.</exception>
        public SalesQuote(decimal vehicleSalePrice, decimal tradeInAmount, decimal salesTaxRate)
            : this(vehicleSalePrice, tradeInAmount, salesTaxRate, Accessories.None, ExteriorFinish.None)
        {
        }

        /// <summary>
        ///  Gets and sets the sale price of the vehicle.
        /// </summary>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the property is set to less than or equal to 0.</exception>
        public decimal VehicleSalePrice
        {
            get
            {
                return vehicleSalePrice;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value",
                                               "The value cannot be less than or equal to 0.");
                }
                vehicleSalePrice = value;
            }
        }

        /// <summary>
        /// Gets and sets the trade in amount. 
        /// </summary>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the property is set to less than 0.</exception>
        public decimal TradeInAmount
        {
            get
            {
                return tradeInAmount;
            }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentOutOfRangeException("value",
                                    "The value cannot be less than 0.");
                }
                tradeInAmount = value;
            }
        }

        /// <summary>
        /// Gets and sets the accessories that were chosen.
        /// </summary>
        public Accessories AccessoriesChosen
        {
            get
            {
                return accessoriesChosen;
            }
            set
            {
                accessoriesChosen = value;
            }
        }

        /// <summary>
        /// Gets and sets the exterior finish that was chosen.
        /// </summary>
        public ExteriorFinish ExteriorFinishChosen
        {
            get
            {
                return exteriorFinishChosen;
            }
            set
            {
                exteriorFinishChosen = value;
            }
        }

        /// <summary>
        /// Gets the cost of accessories chosen.
        /// </summary>
        public decimal AccessoryCost
        {
            get
            {
                decimal accessoryCost = 0.00m;

                switch (accessoriesChosen)
                {
                    case Accessories.StereoSystem:
                        accessoryCost = 505.05m;
                        break;
                    case Accessories.LeatherInterior:
                        accessoryCost = 1010.10m;
                        break;
                    case Accessories.ComputerNavigation:
                        accessoryCost = 1515.15m;
                        break;
                    case Accessories.StereoAndLeather:
                        accessoryCost = 1515.15m;
                        break;
                    case Accessories.StereoAndNavigation:
                        accessoryCost = 2020.20m;
                        break;
                    case Accessories.LeatherAndNavigation:
                        accessoryCost = 2525.25m;
                        break;
                    case Accessories.All:
                        accessoryCost = 3030.30m;
                        break;
                }

                return accessoryCost;
            }
        }

        /// <summary>
        /// Gets the cost of the exterior finish chosen.
        /// </summary>
        public decimal FinishCost
        {
            get
            {
                decimal exteriorFinishCost = 0.00m;

                switch (exteriorFinishChosen)
                {
                    case ExteriorFinish.Standard:
                        exteriorFinishCost = 202.02m;
                        break;
                    case ExteriorFinish.Pearlized:
                        exteriorFinishCost = 404.04m;
                        break;
                    case ExteriorFinish.Custom:
                        exteriorFinishCost = 606.06m;
                        break;
                }

                return exteriorFinishCost;
            }
        }

        /// <summary>
        /// Returns the sum of the vehicle’s sale price, accessories and exterior finish costs.
        /// </summary>
        public decimal SubTotal
        {
            get
            {
                return vehicleSalePrice + AccessoryCost + FinishCost;
            }
        }

        /// <summary>
        /// Gets the amount of tax to charge based on the subtotal.
        /// </summary>
        public decimal SalesTax
        {
            get
            {
                return salesTaxRate * SubTotal;
            }
        }

        /// <summary>
        /// Gets the sum of the subtotal and taxes.
        /// </summary>
        public decimal Total
        {
            get
            {
                return SalesTax + SubTotal;
            }
        }

        /// <summary>
        /// Gets the result of subtracting the trade-in amount from the total.
        /// </summary>
        public decimal AmountDue
        {
            get
            {
                return Total - tradeInAmount;
            }
        }

        /// <summary>
        /// Returns the String representation of a SalesQuote.
        /// </summary>
        /// <returns>Returns the String representation of a SalesQuote.</returns>
        public override string ToString()
        {
            return string.Format("Vehicle Sale Price: {0:C}\nTrade-in Amount: {1:C}\nAccessories Cost: {2:C}\nFinish Cost: {3:C}" +
                "\nSubTotal: {4:C}\nTotal: {5:C}\nAmount Due: {6:C}", vehicleSalePrice, tradeInAmount, AccessoryCost,
               FinishCost, SubTotal, Total, AmountDue);
        }
    }
}