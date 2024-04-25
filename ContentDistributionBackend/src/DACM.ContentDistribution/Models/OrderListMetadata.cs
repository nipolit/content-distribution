/*
 * ContentDistributionBackend
 *
 * Service providing content distribution metadata for ordered digital assets
 *
 * OpenAPI spec version: 0.0.1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace DACM.ContentDistribution.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class OrderListMetadata : IEquatable<OrderListMetadata>
    { 
        /// <summary>
        /// Gets or Sets OrderNumber
        /// </summary>
        [Required]

        [DataMember(Name="orderNumber")]
        public Object OrderNumber { get; set; }

        /// <summary>
        /// Gets or Sets CustomerName
        /// </summary>
        [Required]

        [DataMember(Name="customerName")]
        public Object CustomerName { get; set; }

        /// <summary>
        /// Gets or Sets OrderDate
        /// </summary>
        [Required]

        [DataMember(Name="orderDate")]
        public Object OrderDate { get; set; }

        /// <summary>
        /// Gets or Sets TotalAssets
        /// </summary>
        [Required]

        [DataMember(Name="totalAssets")]
        public Object TotalAssets { get; set; }

        /// <summary>
        /// Gets or Sets Assets
        /// </summary>
        [Required]

        [DataMember(Name="assets")]
        public Object Assets { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OrderListMetadata {\n");
            sb.Append("  OrderNumber: ").Append(OrderNumber).Append("\n");
            sb.Append("  CustomerName: ").Append(CustomerName).Append("\n");
            sb.Append("  OrderDate: ").Append(OrderDate).Append("\n");
            sb.Append("  TotalAssets: ").Append(TotalAssets).Append("\n");
            sb.Append("  Assets: ").Append(Assets).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((OrderListMetadata)obj);
        }

        /// <summary>
        /// Returns true if OrderListMetadata instances are equal
        /// </summary>
        /// <param name="other">Instance of OrderListMetadata to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OrderListMetadata other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    OrderNumber == other.OrderNumber ||
                    OrderNumber != null &&
                    OrderNumber.Equals(other.OrderNumber)
                ) && 
                (
                    CustomerName == other.CustomerName ||
                    CustomerName != null &&
                    CustomerName.Equals(other.CustomerName)
                ) && 
                (
                    OrderDate == other.OrderDate ||
                    OrderDate != null &&
                    OrderDate.Equals(other.OrderDate)
                ) && 
                (
                    TotalAssets == other.TotalAssets ||
                    TotalAssets != null &&
                    TotalAssets.Equals(other.TotalAssets)
                ) && 
                (
                    Assets == other.Assets ||
                    Assets != null &&
                    Assets.Equals(other.Assets)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                    if (OrderNumber != null)
                    hashCode = hashCode * 59 + OrderNumber.GetHashCode();
                    if (CustomerName != null)
                    hashCode = hashCode * 59 + CustomerName.GetHashCode();
                    if (OrderDate != null)
                    hashCode = hashCode * 59 + OrderDate.GetHashCode();
                    if (TotalAssets != null)
                    hashCode = hashCode * 59 + TotalAssets.GetHashCode();
                    if (Assets != null)
                    hashCode = hashCode * 59 + Assets.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(OrderListMetadata left, OrderListMetadata right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(OrderListMetadata left, OrderListMetadata right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}