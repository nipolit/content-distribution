/*
 * AssetMetadataService
 *
 * Service providing asset metadata
 *
 * OpenAPI spec version: 0.0.1
 *
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace DACM.ContentDistribution.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class AssetMetadata : IEquatable<AssetMetadata>
    { 
        /// <summary>
        /// Gets or Sets AssetId
        /// </summary>
        [Required]

        [DataMember(Name="assetId")]
        public string AssetId { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>

        [DataMember(Name="name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>

        [DataMember(Name="description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets FileFormat
        /// </summary>

        [DataMember(Name="fileFormat")]
        public string FileFormat { get; set; }

        /// <summary>
        /// Gets or Sets FileSize
        /// </summary>

        [DataMember(Name="fileSize")]
        public string FileSize { get; set; }

        /// <summary>
        /// Gets or Sets Path
        /// </summary>

        [DataMember(Name="path")]
        public string Path { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AssetMetadata {\n");
            sb.Append("  AssetId: ").Append(AssetId).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  FileFormat: ").Append(FileFormat).Append("\n");
            sb.Append("  FileSize: ").Append(FileSize).Append("\n");
            sb.Append("  Path: ").Append(Path).Append("\n");
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
            return obj.GetType() == GetType() && Equals((AssetMetadata)obj);
        }

        /// <summary>
        /// Returns true if AssetMetadata instances are equal
        /// </summary>
        /// <param name="other">Instance of AssetMetadata to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AssetMetadata other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    AssetId == other.AssetId ||
                    AssetId != null &&
                    AssetId.Equals(other.AssetId)
                ) && 
                (
                    Name == other.Name ||
                    Name != null &&
                    Name.Equals(other.Name)
                ) && 
                (
                    Description == other.Description ||
                    Description != null &&
                    Description.Equals(other.Description)
                ) && 
                (
                    FileFormat == other.FileFormat ||
                    FileFormat != null &&
                    FileFormat.Equals(other.FileFormat)
                ) && 
                (
                    FileSize == other.FileSize ||
                    FileSize != null &&
                    FileSize.Equals(other.FileSize)
                ) && 
                (
                    Path == other.Path ||
                    Path != null &&
                    Path.Equals(other.Path)
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
                    if (AssetId != null)
                    hashCode = hashCode * 59 + AssetId.GetHashCode();
                    if (Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                    if (Description != null)
                    hashCode = hashCode * 59 + Description.GetHashCode();
                    if (FileFormat != null)
                    hashCode = hashCode * 59 + FileFormat.GetHashCode();
                    if (FileSize != null)
                    hashCode = hashCode * 59 + FileSize.GetHashCode();
                    if (Path != null)
                    hashCode = hashCode * 59 + Path.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(AssetMetadata left, AssetMetadata right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AssetMetadata left, AssetMetadata right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}