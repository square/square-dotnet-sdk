namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Utilities;

    /// <summary>
    /// TaxIds.
    /// </summary>
    public class TaxIds
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="TaxIds"/> class.
        /// </summary>
        /// <param name="euVat">eu_vat.</param>
        /// <param name="frSiret">fr_siret.</param>
        /// <param name="frNaf">fr_naf.</param>
        /// <param name="esNif">es_nif.</param>
        public TaxIds(
            string euVat = null,
            string frSiret = null,
            string frNaf = null,
            string esNif = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "eu_vat", false },
                { "fr_siret", false },
                { "fr_naf", false },
                { "es_nif", false }
            };

            if (euVat != null)
            {
                shouldSerialize["eu_vat"] = true;
                this.EuVat = euVat;
            }

            if (frSiret != null)
            {
                shouldSerialize["fr_siret"] = true;
                this.FrSiret = frSiret;
            }

            if (frNaf != null)
            {
                shouldSerialize["fr_naf"] = true;
                this.FrNaf = frNaf;
            }

            if (esNif != null)
            {
                shouldSerialize["es_nif"] = true;
                this.EsNif = esNif;
            }

        }
        internal TaxIds(Dictionary<string, bool> shouldSerialize,
            string euVat = null,
            string frSiret = null,
            string frNaf = null,
            string esNif = null)
        {
            this.shouldSerialize = shouldSerialize;
            EuVat = euVat;
            FrSiret = frSiret;
            FrNaf = frNaf;
            EsNif = esNif;
        }

        /// <summary>
        /// The EU VAT number for this location. For example, `IE3426675K`.
        /// If the EU VAT number is present, it is well-formed and has been
        /// validated with VIES, the VAT Information Exchange System.
        /// </summary>
        [JsonProperty("eu_vat")]
        public string EuVat { get; }

        /// <summary>
        /// The SIRET (Système d'Identification du Répertoire des Entreprises et de leurs Etablissements)
        /// number is a 14-digit code issued by the French INSEE. For example, `39922799000021`.
        /// </summary>
        [JsonProperty("fr_siret")]
        public string FrSiret { get; }

        /// <summary>
        /// The French government uses the NAF (Nomenclature des Activités Françaises) to display and
        /// track economic statistical data. This is also called the APE (Activite Principale de l’Entreprise) code.
        /// For example, `6910Z`.
        /// </summary>
        [JsonProperty("fr_naf")]
        public string FrNaf { get; }

        /// <summary>
        /// The NIF (Numero de Identificacion Fiscal) number is a nine-character tax identifier used in Spain.
        /// If it is present, it has been validated. For example, `73628495A`.
        /// </summary>
        [JsonProperty("es_nif")]
        public string EsNif { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"TaxIds : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEuVat()
        {
            return this.shouldSerialize["eu_vat"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeFrSiret()
        {
            return this.shouldSerialize["fr_siret"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeFrNaf()
        {
            return this.shouldSerialize["fr_naf"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEsNif()
        {
            return this.shouldSerialize["es_nif"];
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

            return obj is TaxIds other &&
                ((this.EuVat == null && other.EuVat == null) || (this.EuVat?.Equals(other.EuVat) == true)) &&
                ((this.FrSiret == null && other.FrSiret == null) || (this.FrSiret?.Equals(other.FrSiret) == true)) &&
                ((this.FrNaf == null && other.FrNaf == null) || (this.FrNaf?.Equals(other.FrNaf) == true)) &&
                ((this.EsNif == null && other.EsNif == null) || (this.EsNif?.Equals(other.EsNif) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1210359385;
            hashCode = HashCode.Combine(this.EuVat, this.FrSiret, this.FrNaf, this.EsNif);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.EuVat = {(this.EuVat == null ? "null" : this.EuVat == string.Empty ? "" : this.EuVat)}");
            toStringOutput.Add($"this.FrSiret = {(this.FrSiret == null ? "null" : this.FrSiret == string.Empty ? "" : this.FrSiret)}");
            toStringOutput.Add($"this.FrNaf = {(this.FrNaf == null ? "null" : this.FrNaf == string.Empty ? "" : this.FrNaf)}");
            toStringOutput.Add($"this.EsNif = {(this.EsNif == null ? "null" : this.EsNif == string.Empty ? "" : this.EsNif)}");
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
                .EsNif(this.EsNif);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "eu_vat", false },
                { "fr_siret", false },
                { "fr_naf", false },
                { "es_nif", false },
            };

            private string euVat;
            private string frSiret;
            private string frNaf;
            private string esNif;

             /// <summary>
             /// EuVat.
             /// </summary>
             /// <param name="euVat"> euVat. </param>
             /// <returns> Builder. </returns>
            public Builder EuVat(string euVat)
            {
                shouldSerialize["eu_vat"] = true;
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
                shouldSerialize["fr_siret"] = true;
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
                shouldSerialize["fr_naf"] = true;
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
                shouldSerialize["es_nif"] = true;
                this.esNif = esNif;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetEuVat()
            {
                this.shouldSerialize["eu_vat"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetFrSiret()
            {
                this.shouldSerialize["fr_siret"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetFrNaf()
            {
                this.shouldSerialize["fr_naf"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetEsNif()
            {
                this.shouldSerialize["es_nif"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> TaxIds. </returns>
            public TaxIds Build()
            {
                return new TaxIds(shouldSerialize,
                    this.euVat,
                    this.frSiret,
                    this.frNaf,
                    this.esNif);
            }
        }
    }
}