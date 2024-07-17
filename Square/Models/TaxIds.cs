namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using APIMatic.Core.Utilities.Converters;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Utilities;

    /// <summary>
    /// TaxIds.
    /// </summary>
    public class TaxIds
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TaxIds"/> class.
        /// </summary>
        /// <param name="euVat">eu_vat.</param>
        /// <param name="frSiret">fr_siret.</param>
        /// <param name="frNaf">fr_naf.</param>
        /// <param name="esNif">es_nif.</param>
        /// <param name="jpQii">jp_qii.</param>
        public TaxIds(
            string euVat = null,
            string frSiret = null,
            string frNaf = null,
            string esNif = null,
            string jpQii = null)
        {
            this.EuVat = euVat;
            this.FrSiret = frSiret;
            this.FrNaf = frNaf;
            this.EsNif = esNif;
            this.JpQii = jpQii;
        }

        /// <summary>
        /// The EU VAT number for this location. For example, `IE3426675K`.
        /// If the EU VAT number is present, it is well-formed and has been
        /// validated with VIES, the VAT Information Exchange System.
        /// </summary>
        [JsonProperty("eu_vat", NullValueHandling = NullValueHandling.Ignore)]
        public string EuVat { get; }

        /// <summary>
        /// The SIRET (Système d'Identification du Répertoire des Entreprises et de leurs Etablissements)
        /// number is a 14-digit code issued by the French INSEE. For example, `39922799000021`.
        /// </summary>
        [JsonProperty("fr_siret", NullValueHandling = NullValueHandling.Ignore)]
        public string FrSiret { get; }

        /// <summary>
        /// The French government uses the NAF (Nomenclature des Activités Françaises) to display and
        /// track economic statistical data. This is also called the APE (Activite Principale de l’Entreprise) code.
        /// For example, `6910Z`.
        /// </summary>
        [JsonProperty("fr_naf", NullValueHandling = NullValueHandling.Ignore)]
        public string FrNaf { get; }

        /// <summary>
        /// The NIF (Numero de Identificacion Fiscal) number is a nine-character tax identifier used in Spain.
        /// If it is present, it has been validated. For example, `73628495A`.
        /// </summary>
        [JsonProperty("es_nif", NullValueHandling = NullValueHandling.Ignore)]
        public string EsNif { get; }

        /// <summary>
        /// The QII (Qualified Invoice Issuer) number is a 14-character tax identifier used in Japan.
        /// For example, `T1234567890123`.
        /// </summary>
        [JsonProperty("jp_qii", NullValueHandling = NullValueHandling.Ignore)]
        public string JpQii { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"TaxIds : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }
            return obj is TaxIds other &&                ((this.EuVat == null && other.EuVat == null) || (this.EuVat?.Equals(other.EuVat) == true)) &&
                ((this.FrSiret == null && other.FrSiret == null) || (this.FrSiret?.Equals(other.FrSiret) == true)) &&
                ((this.FrNaf == null && other.FrNaf == null) || (this.FrNaf?.Equals(other.FrNaf) == true)) &&
                ((this.EsNif == null && other.EsNif == null) || (this.EsNif?.Equals(other.EsNif) == true)) &&
                ((this.JpQii == null && other.JpQii == null) || (this.JpQii?.Equals(other.JpQii) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1902523062;
            hashCode = HashCode.Combine(this.EuVat, this.FrSiret, this.FrNaf, this.EsNif, this.JpQii);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.EuVat = {(this.EuVat == null ? "null" : this.EuVat)}");
            toStringOutput.Add($"this.FrSiret = {(this.FrSiret == null ? "null" : this.FrSiret)}");
            toStringOutput.Add($"this.FrNaf = {(this.FrNaf == null ? "null" : this.FrNaf)}");
            toStringOutput.Add($"this.EsNif = {(this.EsNif == null ? "null" : this.EsNif)}");
            toStringOutput.Add($"this.JpQii = {(this.JpQii == null ? "null" : this.JpQii)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .EuVat(this.EuVat)
                .FrSiret(this.FrSiret)
                .FrNaf(this.FrNaf)
                .EsNif(this.EsNif)
                .JpQii(this.JpQii);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string euVat;
            private string frSiret;
            private string frNaf;
            private string esNif;
            private string jpQii;

             /// <summary>
             /// EuVat.
             /// </summary>
             /// <param name="euVat"> euVat. </param>
             /// <returns> Builder. </returns>
            public Builder EuVat(string euVat)
            {
                this.euVat = euVat;
                return this;
            }

             /// <summary>
             /// FrSiret.
             /// </summary>
             /// <param name="frSiret"> frSiret. </param>
             /// <returns> Builder. </returns>
            public Builder FrSiret(string frSiret)
            {
                this.frSiret = frSiret;
                return this;
            }

             /// <summary>
             /// FrNaf.
             /// </summary>
             /// <param name="frNaf"> frNaf. </param>
             /// <returns> Builder. </returns>
            public Builder FrNaf(string frNaf)
            {
                this.frNaf = frNaf;
                return this;
            }

             /// <summary>
             /// EsNif.
             /// </summary>
             /// <param name="esNif"> esNif. </param>
             /// <returns> Builder. </returns>
            public Builder EsNif(string esNif)
            {
                this.esNif = esNif;
                return this;
            }

             /// <summary>
             /// JpQii.
             /// </summary>
             /// <param name="jpQii"> jpQii. </param>
             /// <returns> Builder. </returns>
            public Builder JpQii(string jpQii)
            {
                this.jpQii = jpQii;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> TaxIds. </returns>
            public TaxIds Build()
            {
                return new TaxIds(
                    this.euVat,
                    this.frSiret,
                    this.frNaf,
                    this.esNif,
                    this.jpQii);
            }
        }
    }
}