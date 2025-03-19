using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<Country>))]
public readonly record struct Country : IStringEnum
{
    public static readonly Country Zz = new(Values.Zz);

    public static readonly Country Ad = new(Values.Ad);

    public static readonly Country Ae = new(Values.Ae);

    public static readonly Country Af = new(Values.Af);

    public static readonly Country Ag = new(Values.Ag);

    public static readonly Country Ai = new(Values.Ai);

    public static readonly Country Al = new(Values.Al);

    public static readonly Country Am = new(Values.Am);

    public static readonly Country Ao = new(Values.Ao);

    public static readonly Country Aq = new(Values.Aq);

    public static readonly Country Ar = new(Values.Ar);

    public static readonly Country As = new(Values.As);

    public static readonly Country At = new(Values.At);

    public static readonly Country Au = new(Values.Au);

    public static readonly Country Aw = new(Values.Aw);

    public static readonly Country Ax = new(Values.Ax);

    public static readonly Country Az = new(Values.Az);

    public static readonly Country Ba = new(Values.Ba);

    public static readonly Country Bb = new(Values.Bb);

    public static readonly Country Bd = new(Values.Bd);

    public static readonly Country Be = new(Values.Be);

    public static readonly Country Bf = new(Values.Bf);

    public static readonly Country Bg = new(Values.Bg);

    public static readonly Country Bh = new(Values.Bh);

    public static readonly Country Bi = new(Values.Bi);

    public static readonly Country Bj = new(Values.Bj);

    public static readonly Country Bl = new(Values.Bl);

    public static readonly Country Bm = new(Values.Bm);

    public static readonly Country Bn = new(Values.Bn);

    public static readonly Country Bo = new(Values.Bo);

    public static readonly Country Bq = new(Values.Bq);

    public static readonly Country Br = new(Values.Br);

    public static readonly Country Bs = new(Values.Bs);

    public static readonly Country Bt = new(Values.Bt);

    public static readonly Country Bv = new(Values.Bv);

    public static readonly Country Bw = new(Values.Bw);

    public static readonly Country By = new(Values.By);

    public static readonly Country Bz = new(Values.Bz);

    public static readonly Country Ca = new(Values.Ca);

    public static readonly Country Cc = new(Values.Cc);

    public static readonly Country Cd = new(Values.Cd);

    public static readonly Country Cf = new(Values.Cf);

    public static readonly Country Cg = new(Values.Cg);

    public static readonly Country Ch = new(Values.Ch);

    public static readonly Country Ci = new(Values.Ci);

    public static readonly Country Ck = new(Values.Ck);

    public static readonly Country Cl = new(Values.Cl);

    public static readonly Country Cm = new(Values.Cm);

    public static readonly Country Cn = new(Values.Cn);

    public static readonly Country Co = new(Values.Co);

    public static readonly Country Cr = new(Values.Cr);

    public static readonly Country Cu = new(Values.Cu);

    public static readonly Country Cv = new(Values.Cv);

    public static readonly Country Cw = new(Values.Cw);

    public static readonly Country Cx = new(Values.Cx);

    public static readonly Country Cy = new(Values.Cy);

    public static readonly Country Cz = new(Values.Cz);

    public static readonly Country De = new(Values.De);

    public static readonly Country Dj = new(Values.Dj);

    public static readonly Country Dk = new(Values.Dk);

    public static readonly Country Dm = new(Values.Dm);

    public static readonly Country Do = new(Values.Do);

    public static readonly Country Dz = new(Values.Dz);

    public static readonly Country Ec = new(Values.Ec);

    public static readonly Country Ee = new(Values.Ee);

    public static readonly Country Eg = new(Values.Eg);

    public static readonly Country Eh = new(Values.Eh);

    public static readonly Country Er = new(Values.Er);

    public static readonly Country Es = new(Values.Es);

    public static readonly Country Et = new(Values.Et);

    public static readonly Country Fi = new(Values.Fi);

    public static readonly Country Fj = new(Values.Fj);

    public static readonly Country Fk = new(Values.Fk);

    public static readonly Country Fm = new(Values.Fm);

    public static readonly Country Fo = new(Values.Fo);

    public static readonly Country Fr = new(Values.Fr);

    public static readonly Country Ga = new(Values.Ga);

    public static readonly Country Gb = new(Values.Gb);

    public static readonly Country Gd = new(Values.Gd);

    public static readonly Country Ge = new(Values.Ge);

    public static readonly Country Gf = new(Values.Gf);

    public static readonly Country Gg = new(Values.Gg);

    public static readonly Country Gh = new(Values.Gh);

    public static readonly Country Gi = new(Values.Gi);

    public static readonly Country Gl = new(Values.Gl);

    public static readonly Country Gm = new(Values.Gm);

    public static readonly Country Gn = new(Values.Gn);

    public static readonly Country Gp = new(Values.Gp);

    public static readonly Country Gq = new(Values.Gq);

    public static readonly Country Gr = new(Values.Gr);

    public static readonly Country Gs = new(Values.Gs);

    public static readonly Country Gt = new(Values.Gt);

    public static readonly Country Gu = new(Values.Gu);

    public static readonly Country Gw = new(Values.Gw);

    public static readonly Country Gy = new(Values.Gy);

    public static readonly Country Hk = new(Values.Hk);

    public static readonly Country Hm = new(Values.Hm);

    public static readonly Country Hn = new(Values.Hn);

    public static readonly Country Hr = new(Values.Hr);

    public static readonly Country Ht = new(Values.Ht);

    public static readonly Country Hu = new(Values.Hu);

    public static readonly Country Id = new(Values.Id);

    public static readonly Country Ie = new(Values.Ie);

    public static readonly Country Il = new(Values.Il);

    public static readonly Country Im = new(Values.Im);

    public static readonly Country In = new(Values.In);

    public static readonly Country Io = new(Values.Io);

    public static readonly Country Iq = new(Values.Iq);

    public static readonly Country Ir = new(Values.Ir);

    public static readonly Country Is = new(Values.Is);

    public static readonly Country It = new(Values.It);

    public static readonly Country Je = new(Values.Je);

    public static readonly Country Jm = new(Values.Jm);

    public static readonly Country Jo = new(Values.Jo);

    public static readonly Country Jp = new(Values.Jp);

    public static readonly Country Ke = new(Values.Ke);

    public static readonly Country Kg = new(Values.Kg);

    public static readonly Country Kh = new(Values.Kh);

    public static readonly Country Ki = new(Values.Ki);

    public static readonly Country Km = new(Values.Km);

    public static readonly Country Kn = new(Values.Kn);

    public static readonly Country Kp = new(Values.Kp);

    public static readonly Country Kr = new(Values.Kr);

    public static readonly Country Kw = new(Values.Kw);

    public static readonly Country Ky = new(Values.Ky);

    public static readonly Country Kz = new(Values.Kz);

    public static readonly Country La = new(Values.La);

    public static readonly Country Lb = new(Values.Lb);

    public static readonly Country Lc = new(Values.Lc);

    public static readonly Country Li = new(Values.Li);

    public static readonly Country Lk = new(Values.Lk);

    public static readonly Country Lr = new(Values.Lr);

    public static readonly Country Ls = new(Values.Ls);

    public static readonly Country Lt = new(Values.Lt);

    public static readonly Country Lu = new(Values.Lu);

    public static readonly Country Lv = new(Values.Lv);

    public static readonly Country Ly = new(Values.Ly);

    public static readonly Country Ma = new(Values.Ma);

    public static readonly Country Mc = new(Values.Mc);

    public static readonly Country Md = new(Values.Md);

    public static readonly Country Me = new(Values.Me);

    public static readonly Country Mf = new(Values.Mf);

    public static readonly Country Mg = new(Values.Mg);

    public static readonly Country Mh = new(Values.Mh);

    public static readonly Country Mk = new(Values.Mk);

    public static readonly Country Ml = new(Values.Ml);

    public static readonly Country Mm = new(Values.Mm);

    public static readonly Country Mn = new(Values.Mn);

    public static readonly Country Mo = new(Values.Mo);

    public static readonly Country Mp = new(Values.Mp);

    public static readonly Country Mq = new(Values.Mq);

    public static readonly Country Mr = new(Values.Mr);

    public static readonly Country Ms = new(Values.Ms);

    public static readonly Country Mt = new(Values.Mt);

    public static readonly Country Mu = new(Values.Mu);

    public static readonly Country Mv = new(Values.Mv);

    public static readonly Country Mw = new(Values.Mw);

    public static readonly Country Mx = new(Values.Mx);

    public static readonly Country My = new(Values.My);

    public static readonly Country Mz = new(Values.Mz);

    public static readonly Country Na = new(Values.Na);

    public static readonly Country Nc = new(Values.Nc);

    public static readonly Country Ne = new(Values.Ne);

    public static readonly Country Nf = new(Values.Nf);

    public static readonly Country Ng = new(Values.Ng);

    public static readonly Country Ni = new(Values.Ni);

    public static readonly Country Nl = new(Values.Nl);

    public static readonly Country No = new(Values.No);

    public static readonly Country Np = new(Values.Np);

    public static readonly Country Nr = new(Values.Nr);

    public static readonly Country Nu = new(Values.Nu);

    public static readonly Country Nz = new(Values.Nz);

    public static readonly Country Om = new(Values.Om);

    public static readonly Country Pa = new(Values.Pa);

    public static readonly Country Pe = new(Values.Pe);

    public static readonly Country Pf = new(Values.Pf);

    public static readonly Country Pg = new(Values.Pg);

    public static readonly Country Ph = new(Values.Ph);

    public static readonly Country Pk = new(Values.Pk);

    public static readonly Country Pl = new(Values.Pl);

    public static readonly Country Pm = new(Values.Pm);

    public static readonly Country Pn = new(Values.Pn);

    public static readonly Country Pr = new(Values.Pr);

    public static readonly Country Ps = new(Values.Ps);

    public static readonly Country Pt = new(Values.Pt);

    public static readonly Country Pw = new(Values.Pw);

    public static readonly Country Py = new(Values.Py);

    public static readonly Country Qa = new(Values.Qa);

    public static readonly Country Re = new(Values.Re);

    public static readonly Country Ro = new(Values.Ro);

    public static readonly Country Rs = new(Values.Rs);

    public static readonly Country Ru = new(Values.Ru);

    public static readonly Country Rw = new(Values.Rw);

    public static readonly Country Sa = new(Values.Sa);

    public static readonly Country Sb = new(Values.Sb);

    public static readonly Country Sc = new(Values.Sc);

    public static readonly Country Sd = new(Values.Sd);

    public static readonly Country Se = new(Values.Se);

    public static readonly Country Sg = new(Values.Sg);

    public static readonly Country Sh = new(Values.Sh);

    public static readonly Country Si = new(Values.Si);

    public static readonly Country Sj = new(Values.Sj);

    public static readonly Country Sk = new(Values.Sk);

    public static readonly Country Sl = new(Values.Sl);

    public static readonly Country Sm = new(Values.Sm);

    public static readonly Country Sn = new(Values.Sn);

    public static readonly Country So = new(Values.So);

    public static readonly Country Sr = new(Values.Sr);

    public static readonly Country Ss = new(Values.Ss);

    public static readonly Country St = new(Values.St);

    public static readonly Country Sv = new(Values.Sv);

    public static readonly Country Sx = new(Values.Sx);

    public static readonly Country Sy = new(Values.Sy);

    public static readonly Country Sz = new(Values.Sz);

    public static readonly Country Tc = new(Values.Tc);

    public static readonly Country Td = new(Values.Td);

    public static readonly Country Tf = new(Values.Tf);

    public static readonly Country Tg = new(Values.Tg);

    public static readonly Country Th = new(Values.Th);

    public static readonly Country Tj = new(Values.Tj);

    public static readonly Country Tk = new(Values.Tk);

    public static readonly Country Tl = new(Values.Tl);

    public static readonly Country Tm = new(Values.Tm);

    public static readonly Country Tn = new(Values.Tn);

    public static readonly Country To = new(Values.To);

    public static readonly Country Tr = new(Values.Tr);

    public static readonly Country Tt = new(Values.Tt);

    public static readonly Country Tv = new(Values.Tv);

    public static readonly Country Tw = new(Values.Tw);

    public static readonly Country Tz = new(Values.Tz);

    public static readonly Country Ua = new(Values.Ua);

    public static readonly Country Ug = new(Values.Ug);

    public static readonly Country Um = new(Values.Um);

    public static readonly Country Us = new(Values.Us);

    public static readonly Country Uy = new(Values.Uy);

    public static readonly Country Uz = new(Values.Uz);

    public static readonly Country Va = new(Values.Va);

    public static readonly Country Vc = new(Values.Vc);

    public static readonly Country Ve = new(Values.Ve);

    public static readonly Country Vg = new(Values.Vg);

    public static readonly Country Vi = new(Values.Vi);

    public static readonly Country Vn = new(Values.Vn);

    public static readonly Country Vu = new(Values.Vu);

    public static readonly Country Wf = new(Values.Wf);

    public static readonly Country Ws = new(Values.Ws);

    public static readonly Country Ye = new(Values.Ye);

    public static readonly Country Yt = new(Values.Yt);

    public static readonly Country Za = new(Values.Za);

    public static readonly Country Zm = new(Values.Zm);

    public static readonly Country Zw = new(Values.Zw);

    public Country(string value)
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
    public static Country FromCustom(string value)
    {
        return new Country(value);
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

    public static bool operator ==(Country value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(Country value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(Country value) => value.Value;

    public static explicit operator Country(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string Zz = "ZZ";

        public const string Ad = "AD";

        public const string Ae = "AE";

        public const string Af = "AF";

        public const string Ag = "AG";

        public const string Ai = "AI";

        public const string Al = "AL";

        public const string Am = "AM";

        public const string Ao = "AO";

        public const string Aq = "AQ";

        public const string Ar = "AR";

        public const string As = "AS";

        public const string At = "AT";

        public const string Au = "AU";

        public const string Aw = "AW";

        public const string Ax = "AX";

        public const string Az = "AZ";

        public const string Ba = "BA";

        public const string Bb = "BB";

        public const string Bd = "BD";

        public const string Be = "BE";

        public const string Bf = "BF";

        public const string Bg = "BG";

        public const string Bh = "BH";

        public const string Bi = "BI";

        public const string Bj = "BJ";

        public const string Bl = "BL";

        public const string Bm = "BM";

        public const string Bn = "BN";

        public const string Bo = "BO";

        public const string Bq = "BQ";

        public const string Br = "BR";

        public const string Bs = "BS";

        public const string Bt = "BT";

        public const string Bv = "BV";

        public const string Bw = "BW";

        public const string By = "BY";

        public const string Bz = "BZ";

        public const string Ca = "CA";

        public const string Cc = "CC";

        public const string Cd = "CD";

        public const string Cf = "CF";

        public const string Cg = "CG";

        public const string Ch = "CH";

        public const string Ci = "CI";

        public const string Ck = "CK";

        public const string Cl = "CL";

        public const string Cm = "CM";

        public const string Cn = "CN";

        public const string Co = "CO";

        public const string Cr = "CR";

        public const string Cu = "CU";

        public const string Cv = "CV";

        public const string Cw = "CW";

        public const string Cx = "CX";

        public const string Cy = "CY";

        public const string Cz = "CZ";

        public const string De = "DE";

        public const string Dj = "DJ";

        public const string Dk = "DK";

        public const string Dm = "DM";

        public const string Do = "DO";

        public const string Dz = "DZ";

        public const string Ec = "EC";

        public const string Ee = "EE";

        public const string Eg = "EG";

        public const string Eh = "EH";

        public const string Er = "ER";

        public const string Es = "ES";

        public const string Et = "ET";

        public const string Fi = "FI";

        public const string Fj = "FJ";

        public const string Fk = "FK";

        public const string Fm = "FM";

        public const string Fo = "FO";

        public const string Fr = "FR";

        public const string Ga = "GA";

        public const string Gb = "GB";

        public const string Gd = "GD";

        public const string Ge = "GE";

        public const string Gf = "GF";

        public const string Gg = "GG";

        public const string Gh = "GH";

        public const string Gi = "GI";

        public const string Gl = "GL";

        public const string Gm = "GM";

        public const string Gn = "GN";

        public const string Gp = "GP";

        public const string Gq = "GQ";

        public const string Gr = "GR";

        public const string Gs = "GS";

        public const string Gt = "GT";

        public const string Gu = "GU";

        public const string Gw = "GW";

        public const string Gy = "GY";

        public const string Hk = "HK";

        public const string Hm = "HM";

        public const string Hn = "HN";

        public const string Hr = "HR";

        public const string Ht = "HT";

        public const string Hu = "HU";

        public const string Id = "ID";

        public const string Ie = "IE";

        public const string Il = "IL";

        public const string Im = "IM";

        public const string In = "IN";

        public const string Io = "IO";

        public const string Iq = "IQ";

        public const string Ir = "IR";

        public const string Is = "IS";

        public const string It = "IT";

        public const string Je = "JE";

        public const string Jm = "JM";

        public const string Jo = "JO";

        public const string Jp = "JP";

        public const string Ke = "KE";

        public const string Kg = "KG";

        public const string Kh = "KH";

        public const string Ki = "KI";

        public const string Km = "KM";

        public const string Kn = "KN";

        public const string Kp = "KP";

        public const string Kr = "KR";

        public const string Kw = "KW";

        public const string Ky = "KY";

        public const string Kz = "KZ";

        public const string La = "LA";

        public const string Lb = "LB";

        public const string Lc = "LC";

        public const string Li = "LI";

        public const string Lk = "LK";

        public const string Lr = "LR";

        public const string Ls = "LS";

        public const string Lt = "LT";

        public const string Lu = "LU";

        public const string Lv = "LV";

        public const string Ly = "LY";

        public const string Ma = "MA";

        public const string Mc = "MC";

        public const string Md = "MD";

        public const string Me = "ME";

        public const string Mf = "MF";

        public const string Mg = "MG";

        public const string Mh = "MH";

        public const string Mk = "MK";

        public const string Ml = "ML";

        public const string Mm = "MM";

        public const string Mn = "MN";

        public const string Mo = "MO";

        public const string Mp = "MP";

        public const string Mq = "MQ";

        public const string Mr = "MR";

        public const string Ms = "MS";

        public const string Mt = "MT";

        public const string Mu = "MU";

        public const string Mv = "MV";

        public const string Mw = "MW";

        public const string Mx = "MX";

        public const string My = "MY";

        public const string Mz = "MZ";

        public const string Na = "NA";

        public const string Nc = "NC";

        public const string Ne = "NE";

        public const string Nf = "NF";

        public const string Ng = "NG";

        public const string Ni = "NI";

        public const string Nl = "NL";

        public const string No = "NO";

        public const string Np = "NP";

        public const string Nr = "NR";

        public const string Nu = "NU";

        public const string Nz = "NZ";

        public const string Om = "OM";

        public const string Pa = "PA";

        public const string Pe = "PE";

        public const string Pf = "PF";

        public const string Pg = "PG";

        public const string Ph = "PH";

        public const string Pk = "PK";

        public const string Pl = "PL";

        public const string Pm = "PM";

        public const string Pn = "PN";

        public const string Pr = "PR";

        public const string Ps = "PS";

        public const string Pt = "PT";

        public const string Pw = "PW";

        public const string Py = "PY";

        public const string Qa = "QA";

        public const string Re = "RE";

        public const string Ro = "RO";

        public const string Rs = "RS";

        public const string Ru = "RU";

        public const string Rw = "RW";

        public const string Sa = "SA";

        public const string Sb = "SB";

        public const string Sc = "SC";

        public const string Sd = "SD";

        public const string Se = "SE";

        public const string Sg = "SG";

        public const string Sh = "SH";

        public const string Si = "SI";

        public const string Sj = "SJ";

        public const string Sk = "SK";

        public const string Sl = "SL";

        public const string Sm = "SM";

        public const string Sn = "SN";

        public const string So = "SO";

        public const string Sr = "SR";

        public const string Ss = "SS";

        public const string St = "ST";

        public const string Sv = "SV";

        public const string Sx = "SX";

        public const string Sy = "SY";

        public const string Sz = "SZ";

        public const string Tc = "TC";

        public const string Td = "TD";

        public const string Tf = "TF";

        public const string Tg = "TG";

        public const string Th = "TH";

        public const string Tj = "TJ";

        public const string Tk = "TK";

        public const string Tl = "TL";

        public const string Tm = "TM";

        public const string Tn = "TN";

        public const string To = "TO";

        public const string Tr = "TR";

        public const string Tt = "TT";

        public const string Tv = "TV";

        public const string Tw = "TW";

        public const string Tz = "TZ";

        public const string Ua = "UA";

        public const string Ug = "UG";

        public const string Um = "UM";

        public const string Us = "US";

        public const string Uy = "UY";

        public const string Uz = "UZ";

        public const string Va = "VA";

        public const string Vc = "VC";

        public const string Ve = "VE";

        public const string Vg = "VG";

        public const string Vi = "VI";

        public const string Vn = "VN";

        public const string Vu = "VU";

        public const string Wf = "WF";

        public const string Ws = "WS";

        public const string Ye = "YE";

        public const string Yt = "YT";

        public const string Za = "ZA";

        public const string Zm = "ZM";

        public const string Zw = "ZW";
    }
}
