using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<Currency>))]
public readonly record struct Currency : IStringEnum
{
    public static readonly Currency UnknownCurrency = new(Values.UnknownCurrency);

    public static readonly Currency Aed = new(Values.Aed);

    public static readonly Currency Afn = new(Values.Afn);

    public static readonly Currency All = new(Values.All);

    public static readonly Currency Amd = new(Values.Amd);

    public static readonly Currency Ang = new(Values.Ang);

    public static readonly Currency Aoa = new(Values.Aoa);

    public static readonly Currency Ars = new(Values.Ars);

    public static readonly Currency Aud = new(Values.Aud);

    public static readonly Currency Awg = new(Values.Awg);

    public static readonly Currency Azn = new(Values.Azn);

    public static readonly Currency Bam = new(Values.Bam);

    public static readonly Currency Bbd = new(Values.Bbd);

    public static readonly Currency Bdt = new(Values.Bdt);

    public static readonly Currency Bgn = new(Values.Bgn);

    public static readonly Currency Bhd = new(Values.Bhd);

    public static readonly Currency Bif = new(Values.Bif);

    public static readonly Currency Bmd = new(Values.Bmd);

    public static readonly Currency Bnd = new(Values.Bnd);

    public static readonly Currency Bob = new(Values.Bob);

    public static readonly Currency Bov = new(Values.Bov);

    public static readonly Currency Brl = new(Values.Brl);

    public static readonly Currency Bsd = new(Values.Bsd);

    public static readonly Currency Btn = new(Values.Btn);

    public static readonly Currency Bwp = new(Values.Bwp);

    public static readonly Currency Byr = new(Values.Byr);

    public static readonly Currency Bzd = new(Values.Bzd);

    public static readonly Currency Cad = new(Values.Cad);

    public static readonly Currency Cdf = new(Values.Cdf);

    public static readonly Currency Che = new(Values.Che);

    public static readonly Currency Chf = new(Values.Chf);

    public static readonly Currency Chw = new(Values.Chw);

    public static readonly Currency Clf = new(Values.Clf);

    public static readonly Currency Clp = new(Values.Clp);

    public static readonly Currency Cny = new(Values.Cny);

    public static readonly Currency Cop = new(Values.Cop);

    public static readonly Currency Cou = new(Values.Cou);

    public static readonly Currency Crc = new(Values.Crc);

    public static readonly Currency Cuc = new(Values.Cuc);

    public static readonly Currency Cup = new(Values.Cup);

    public static readonly Currency Cve = new(Values.Cve);

    public static readonly Currency Czk = new(Values.Czk);

    public static readonly Currency Djf = new(Values.Djf);

    public static readonly Currency Dkk = new(Values.Dkk);

    public static readonly Currency Dop = new(Values.Dop);

    public static readonly Currency Dzd = new(Values.Dzd);

    public static readonly Currency Egp = new(Values.Egp);

    public static readonly Currency Ern = new(Values.Ern);

    public static readonly Currency Etb = new(Values.Etb);

    public static readonly Currency Eur = new(Values.Eur);

    public static readonly Currency Fjd = new(Values.Fjd);

    public static readonly Currency Fkp = new(Values.Fkp);

    public static readonly Currency Gbp = new(Values.Gbp);

    public static readonly Currency Gel = new(Values.Gel);

    public static readonly Currency Ghs = new(Values.Ghs);

    public static readonly Currency Gip = new(Values.Gip);

    public static readonly Currency Gmd = new(Values.Gmd);

    public static readonly Currency Gnf = new(Values.Gnf);

    public static readonly Currency Gtq = new(Values.Gtq);

    public static readonly Currency Gyd = new(Values.Gyd);

    public static readonly Currency Hkd = new(Values.Hkd);

    public static readonly Currency Hnl = new(Values.Hnl);

    public static readonly Currency Hrk = new(Values.Hrk);

    public static readonly Currency Htg = new(Values.Htg);

    public static readonly Currency Huf = new(Values.Huf);

    public static readonly Currency Idr = new(Values.Idr);

    public static readonly Currency Ils = new(Values.Ils);

    public static readonly Currency Inr = new(Values.Inr);

    public static readonly Currency Iqd = new(Values.Iqd);

    public static readonly Currency Irr = new(Values.Irr);

    public static readonly Currency Isk = new(Values.Isk);

    public static readonly Currency Jmd = new(Values.Jmd);

    public static readonly Currency Jod = new(Values.Jod);

    public static readonly Currency Jpy = new(Values.Jpy);

    public static readonly Currency Kes = new(Values.Kes);

    public static readonly Currency Kgs = new(Values.Kgs);

    public static readonly Currency Khr = new(Values.Khr);

    public static readonly Currency Kmf = new(Values.Kmf);

    public static readonly Currency Kpw = new(Values.Kpw);

    public static readonly Currency Krw = new(Values.Krw);

    public static readonly Currency Kwd = new(Values.Kwd);

    public static readonly Currency Kyd = new(Values.Kyd);

    public static readonly Currency Kzt = new(Values.Kzt);

    public static readonly Currency Lak = new(Values.Lak);

    public static readonly Currency Lbp = new(Values.Lbp);

    public static readonly Currency Lkr = new(Values.Lkr);

    public static readonly Currency Lrd = new(Values.Lrd);

    public static readonly Currency Lsl = new(Values.Lsl);

    public static readonly Currency Ltl = new(Values.Ltl);

    public static readonly Currency Lvl = new(Values.Lvl);

    public static readonly Currency Lyd = new(Values.Lyd);

    public static readonly Currency Mad = new(Values.Mad);

    public static readonly Currency Mdl = new(Values.Mdl);

    public static readonly Currency Mga = new(Values.Mga);

    public static readonly Currency Mkd = new(Values.Mkd);

    public static readonly Currency Mmk = new(Values.Mmk);

    public static readonly Currency Mnt = new(Values.Mnt);

    public static readonly Currency Mop = new(Values.Mop);

    public static readonly Currency Mro = new(Values.Mro);

    public static readonly Currency Mur = new(Values.Mur);

    public static readonly Currency Mvr = new(Values.Mvr);

    public static readonly Currency Mwk = new(Values.Mwk);

    public static readonly Currency Mxn = new(Values.Mxn);

    public static readonly Currency Mxv = new(Values.Mxv);

    public static readonly Currency Myr = new(Values.Myr);

    public static readonly Currency Mzn = new(Values.Mzn);

    public static readonly Currency Nad = new(Values.Nad);

    public static readonly Currency Ngn = new(Values.Ngn);

    public static readonly Currency Nio = new(Values.Nio);

    public static readonly Currency Nok = new(Values.Nok);

    public static readonly Currency Npr = new(Values.Npr);

    public static readonly Currency Nzd = new(Values.Nzd);

    public static readonly Currency Omr = new(Values.Omr);

    public static readonly Currency Pab = new(Values.Pab);

    public static readonly Currency Pen = new(Values.Pen);

    public static readonly Currency Pgk = new(Values.Pgk);

    public static readonly Currency Php = new(Values.Php);

    public static readonly Currency Pkr = new(Values.Pkr);

    public static readonly Currency Pln = new(Values.Pln);

    public static readonly Currency Pyg = new(Values.Pyg);

    public static readonly Currency Qar = new(Values.Qar);

    public static readonly Currency Ron = new(Values.Ron);

    public static readonly Currency Rsd = new(Values.Rsd);

    public static readonly Currency Rub = new(Values.Rub);

    public static readonly Currency Rwf = new(Values.Rwf);

    public static readonly Currency Sar = new(Values.Sar);

    public static readonly Currency Sbd = new(Values.Sbd);

    public static readonly Currency Scr = new(Values.Scr);

    public static readonly Currency Sdg = new(Values.Sdg);

    public static readonly Currency Sek = new(Values.Sek);

    public static readonly Currency Sgd = new(Values.Sgd);

    public static readonly Currency Shp = new(Values.Shp);

    public static readonly Currency Sll = new(Values.Sll);

    public static readonly Currency Sle = new(Values.Sle);

    public static readonly Currency Sos = new(Values.Sos);

    public static readonly Currency Srd = new(Values.Srd);

    public static readonly Currency Ssp = new(Values.Ssp);

    public static readonly Currency Std = new(Values.Std);

    public static readonly Currency Svc = new(Values.Svc);

    public static readonly Currency Syp = new(Values.Syp);

    public static readonly Currency Szl = new(Values.Szl);

    public static readonly Currency Thb = new(Values.Thb);

    public static readonly Currency Tjs = new(Values.Tjs);

    public static readonly Currency Tmt = new(Values.Tmt);

    public static readonly Currency Tnd = new(Values.Tnd);

    public static readonly Currency Top = new(Values.Top);

    public static readonly Currency Try = new(Values.Try);

    public static readonly Currency Ttd = new(Values.Ttd);

    public static readonly Currency Twd = new(Values.Twd);

    public static readonly Currency Tzs = new(Values.Tzs);

    public static readonly Currency Uah = new(Values.Uah);

    public static readonly Currency Ugx = new(Values.Ugx);

    public static readonly Currency Usd = new(Values.Usd);

    public static readonly Currency Usn = new(Values.Usn);

    public static readonly Currency Uss = new(Values.Uss);

    public static readonly Currency Uyi = new(Values.Uyi);

    public static readonly Currency Uyu = new(Values.Uyu);

    public static readonly Currency Uzs = new(Values.Uzs);

    public static readonly Currency Vef = new(Values.Vef);

    public static readonly Currency Vnd = new(Values.Vnd);

    public static readonly Currency Vuv = new(Values.Vuv);

    public static readonly Currency Wst = new(Values.Wst);

    public static readonly Currency Xaf = new(Values.Xaf);

    public static readonly Currency Xag = new(Values.Xag);

    public static readonly Currency Xau = new(Values.Xau);

    public static readonly Currency Xba = new(Values.Xba);

    public static readonly Currency Xbb = new(Values.Xbb);

    public static readonly Currency Xbc = new(Values.Xbc);

    public static readonly Currency Xbd = new(Values.Xbd);

    public static readonly Currency Xcd = new(Values.Xcd);

    public static readonly Currency Xdr = new(Values.Xdr);

    public static readonly Currency Xof = new(Values.Xof);

    public static readonly Currency Xpd = new(Values.Xpd);

    public static readonly Currency Xpf = new(Values.Xpf);

    public static readonly Currency Xpt = new(Values.Xpt);

    public static readonly Currency Xts = new(Values.Xts);

    public static readonly Currency Xxx = new(Values.Xxx);

    public static readonly Currency Yer = new(Values.Yer);

    public static readonly Currency Zar = new(Values.Zar);

    public static readonly Currency Zmk = new(Values.Zmk);

    public static readonly Currency Zmw = new(Values.Zmw);

    public static readonly Currency Btc = new(Values.Btc);

    public static readonly Currency Xus = new(Values.Xus);

    public Currency(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static Currency FromCustom(string value)
    {
        return new Currency(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(Currency value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(Currency value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(Currency value) => value.Value;

    public static explicit operator Currency(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string UnknownCurrency = "UNKNOWN_CURRENCY";

        public const string Aed = "AED";

        public const string Afn = "AFN";

        public const string All = "ALL";

        public const string Amd = "AMD";

        public const string Ang = "ANG";

        public const string Aoa = "AOA";

        public const string Ars = "ARS";

        public const string Aud = "AUD";

        public const string Awg = "AWG";

        public const string Azn = "AZN";

        public const string Bam = "BAM";

        public const string Bbd = "BBD";

        public const string Bdt = "BDT";

        public const string Bgn = "BGN";

        public const string Bhd = "BHD";

        public const string Bif = "BIF";

        public const string Bmd = "BMD";

        public const string Bnd = "BND";

        public const string Bob = "BOB";

        public const string Bov = "BOV";

        public const string Brl = "BRL";

        public const string Bsd = "BSD";

        public const string Btn = "BTN";

        public const string Bwp = "BWP";

        public const string Byr = "BYR";

        public const string Bzd = "BZD";

        public const string Cad = "CAD";

        public const string Cdf = "CDF";

        public const string Che = "CHE";

        public const string Chf = "CHF";

        public const string Chw = "CHW";

        public const string Clf = "CLF";

        public const string Clp = "CLP";

        public const string Cny = "CNY";

        public const string Cop = "COP";

        public const string Cou = "COU";

        public const string Crc = "CRC";

        public const string Cuc = "CUC";

        public const string Cup = "CUP";

        public const string Cve = "CVE";

        public const string Czk = "CZK";

        public const string Djf = "DJF";

        public const string Dkk = "DKK";

        public const string Dop = "DOP";

        public const string Dzd = "DZD";

        public const string Egp = "EGP";

        public const string Ern = "ERN";

        public const string Etb = "ETB";

        public const string Eur = "EUR";

        public const string Fjd = "FJD";

        public const string Fkp = "FKP";

        public const string Gbp = "GBP";

        public const string Gel = "GEL";

        public const string Ghs = "GHS";

        public const string Gip = "GIP";

        public const string Gmd = "GMD";

        public const string Gnf = "GNF";

        public const string Gtq = "GTQ";

        public const string Gyd = "GYD";

        public const string Hkd = "HKD";

        public const string Hnl = "HNL";

        public const string Hrk = "HRK";

        public const string Htg = "HTG";

        public const string Huf = "HUF";

        public const string Idr = "IDR";

        public const string Ils = "ILS";

        public const string Inr = "INR";

        public const string Iqd = "IQD";

        public const string Irr = "IRR";

        public const string Isk = "ISK";

        public const string Jmd = "JMD";

        public const string Jod = "JOD";

        public const string Jpy = "JPY";

        public const string Kes = "KES";

        public const string Kgs = "KGS";

        public const string Khr = "KHR";

        public const string Kmf = "KMF";

        public const string Kpw = "KPW";

        public const string Krw = "KRW";

        public const string Kwd = "KWD";

        public const string Kyd = "KYD";

        public const string Kzt = "KZT";

        public const string Lak = "LAK";

        public const string Lbp = "LBP";

        public const string Lkr = "LKR";

        public const string Lrd = "LRD";

        public const string Lsl = "LSL";

        public const string Ltl = "LTL";

        public const string Lvl = "LVL";

        public const string Lyd = "LYD";

        public const string Mad = "MAD";

        public const string Mdl = "MDL";

        public const string Mga = "MGA";

        public const string Mkd = "MKD";

        public const string Mmk = "MMK";

        public const string Mnt = "MNT";

        public const string Mop = "MOP";

        public const string Mro = "MRO";

        public const string Mur = "MUR";

        public const string Mvr = "MVR";

        public const string Mwk = "MWK";

        public const string Mxn = "MXN";

        public const string Mxv = "MXV";

        public const string Myr = "MYR";

        public const string Mzn = "MZN";

        public const string Nad = "NAD";

        public const string Ngn = "NGN";

        public const string Nio = "NIO";

        public const string Nok = "NOK";

        public const string Npr = "NPR";

        public const string Nzd = "NZD";

        public const string Omr = "OMR";

        public const string Pab = "PAB";

        public const string Pen = "PEN";

        public const string Pgk = "PGK";

        public const string Php = "PHP";

        public const string Pkr = "PKR";

        public const string Pln = "PLN";

        public const string Pyg = "PYG";

        public const string Qar = "QAR";

        public const string Ron = "RON";

        public const string Rsd = "RSD";

        public const string Rub = "RUB";

        public const string Rwf = "RWF";

        public const string Sar = "SAR";

        public const string Sbd = "SBD";

        public const string Scr = "SCR";

        public const string Sdg = "SDG";

        public const string Sek = "SEK";

        public const string Sgd = "SGD";

        public const string Shp = "SHP";

        public const string Sll = "SLL";

        public const string Sle = "SLE";

        public const string Sos = "SOS";

        public const string Srd = "SRD";

        public const string Ssp = "SSP";

        public const string Std = "STD";

        public const string Svc = "SVC";

        public const string Syp = "SYP";

        public const string Szl = "SZL";

        public const string Thb = "THB";

        public const string Tjs = "TJS";

        public const string Tmt = "TMT";

        public const string Tnd = "TND";

        public const string Top = "TOP";

        public const string Try = "TRY";

        public const string Ttd = "TTD";

        public const string Twd = "TWD";

        public const string Tzs = "TZS";

        public const string Uah = "UAH";

        public const string Ugx = "UGX";

        public const string Usd = "USD";

        public const string Usn = "USN";

        public const string Uss = "USS";

        public const string Uyi = "UYI";

        public const string Uyu = "UYU";

        public const string Uzs = "UZS";

        public const string Vef = "VEF";

        public const string Vnd = "VND";

        public const string Vuv = "VUV";

        public const string Wst = "WST";

        public const string Xaf = "XAF";

        public const string Xag = "XAG";

        public const string Xau = "XAU";

        public const string Xba = "XBA";

        public const string Xbb = "XBB";

        public const string Xbc = "XBC";

        public const string Xbd = "XBD";

        public const string Xcd = "XCD";

        public const string Xdr = "XDR";

        public const string Xof = "XOF";

        public const string Xpd = "XPD";

        public const string Xpf = "XPF";

        public const string Xpt = "XPT";

        public const string Xts = "XTS";

        public const string Xxx = "XXX";

        public const string Yer = "YER";

        public const string Zar = "ZAR";

        public const string Zmk = "ZMK";

        public const string Zmw = "ZMW";

        public const string Btc = "BTC";

        public const string Xus = "XUS";
    }
}
