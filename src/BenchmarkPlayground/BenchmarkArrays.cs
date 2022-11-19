using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using J2N;
using RandomizedTesting.Generators;
//using J2N.Numerics;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace BenchmarkPlayground
{
    [MemoryDiagnoser]
    [MediumRunJob]
    //[Config(typeof(Config))]
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    public class BenchmarkArrays
    {
        //private class Config : ManualConfig
        //{
        //    public Config()
        //    {
                
        //    }
        //}


        public const int Iterations = 100;

        //public static readonly byte[] ByteArray1 = new byte[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
        //public static readonly byte[] ByteArray1_Equal = new byte[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
        //public static readonly byte[] ByteArray1_NotEqual = new byte[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 2 };


        //public static readonly byte[] ByteArray2 = new byte[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };

        //private byte[] DestByteArray1;


        //public static readonly int[] Int32Array2 = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };

        //private int[] DestInt32Array1;

        //public static readonly long[] Int64Array2 = new long[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };

        //private long[] DestInt64Array2;

        //public static readonly char[] CharArray2 = new char[] { (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0 };
        //private char[] DestCharArray2;

        //public static readonly MyClass[] ObjArray2 = new MyClass[] { new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass() };
        //private MyClass[] DestObjArray2;


        //public static readonly string[] StringArray2 = new string[] { "cybvmnywh", "byerjxqqjstmw", "yldpbdfkgzbnekujl", "vzmbk", "eojzgijavearoxbp", "ljewtfw", "ghgsjpakqltl", "pvyskuebe", "ipanadtxelrbfnzslnf", "qdjct", "gsqhsqfbn", "fydugatjjn", "rrpjknvqwpwnochz", "eonuqntusbdxmp", "vbafqe", "bvfuvzovr", "pgjwqiwwvpyet", "ugqbajbur", "zjvrmpi", "xipbh", "quqnugjx", "zwubypoimyqz", "fpnpvpgybwaiz", "rzrtp", "ktyhtrthvib", "fdasoyamsvfwpqrfwhp", "ziespbnd", "gzcaxyeupnnjkrurwma", "kdzyrphrmnfsgit", "qkvslzbjbpodrfrb", "avrtye", "ougyksl", "lqvvpwrfiohqococsx", "puzvphmwefgnz", "dplmbzjfrnfbtwuwzs", "qvpsgqudarftgzsljuh", "kjtiyydudvf", "wlkswvgsyqb", "navsr", "njekqiwhnmzllksjmy", "kzhdmvybzyclenar", "egosdlpqyl", "xbmsqids", "yephnsgn", "umyuwv", "khtaae", "smqtgfhjgt", "zsnffjdqvpjxgjyaajl", "bciolrddn", "oeiuvlxc", "npwhidpbqgvzwzdnaa", "cigsmx", "zjvripdslasinax", "qsaez", "ejfejbhrxjxrygtni", "fpgainvhbntn", "dauugbhtvyjuwybf", "rzkdaa", "wgewoqjambputgzkhrsn", "oeiiacjckjq", "xyiqkbucokchoaq", "gcswfgtwpirax", "eefdeazyynufuxjh", "dpwaszjgtrlweqn", "gakgum", "temaqom", "teoqfg", "qjoqphlqnew", "dtbkdyjwl", "mnllhkvtum", "vmawspphpnu", "znnfwiwyqoqooiz", "qixdppvmyjmabdx", "qeqitmypreufurxuu", "jhlnnqbc", "kketmmuabvsnwfsgr", "pvzxqioa", "tbpgjxm", "dcjbvci", "cdpkhyldvcwxuxcz", "jdgckdx", "uglqsyuopceervzvm", "dkhlhmftm", "ugexzhk", "njlpavulclbw", "jatzimdqpmysvuakvsvo", "phbhjfcsrcihjsa", "qbksgufgyxnvvex", "nykcm", "hwolifv", "bfsgc", "outhcwewggjhjdszjxcl", "oedgxprfzmye", "awnelfthqwfo", "fbbapcvfwrshrtum", "bnjndnoolqajkxuhhq", "arckzonz", "cdqma", "weuxjameknrz", "cmsdlhbowbpqcizwujy", "yhhgqpzzs", "kzexr", "gqdsylnyoyuciu", "txvzhv", "womnsxu", "pejisqtbdkdt", "saphqxqvg", "mysxzmonpqscsamnf", "wnfiki", "uhjowuznsm", "ayogpupcpkukgfpusj", "rxjgboekbyenk", "imklpwfbwdujzrohji", "ldnuovwxohx", "aztkjjiuks", "aystshfmzmvxirih", "dskihvz", "xqzivrnmevpeuwi", "xvylzxxduftaxeq", "dmmgsndpttsucxgozo", "xygdjqtsquecoaxzt", "ocyue", "qtdpmabst", "ntetzsutim", "krldgpo", "chzaw", "frtlxvg", "kdwrzkpewaqgujlor", "mrhpcnfk", "qdciwen", "ionqyjcvad", "yvrghwblhjxqcosmuwz", "ajlnmdhzpeotufkdort", "dogcoxhzwcniugpm", "vhilcqdm", "euqdgoyymdgywck", "geaynmuhzg", "idwbsroqjs", "zexjtfd", "yyugfges", "hrigxyyeudyathxnq", "zrwjolfhxtdfwpbvovcg", "fimkcbwfkkpuauurqz", "ogjpvdzjfa", "alxmczdjfxqn", "kpwhajuolp", "takfzfzbnmxyhq", "qfxmlxohxufcfzpj", "eppmnm", "wztchbwhmyr", "axocbwghaikzihsxsxgp", "wqatto", "twtficibxburxkkp", "xaacfqflvo", "ohkqmyymgkyz", "crvmrkvotxqch", "aaiivn", "lcoqsxstcawq", "namjc", "xxckyyo", "znmmssisexywirdaeds", "fbfgkurt", "fwpxkpxsqohrzn", "kdmtjckftpglamx", "eylcylkvgox", "emdtvtfggytb", "gpwynacgrpwrbk", "uycuttfmsgwvq", "yvbfngsqiexi", "dkwpyubgbuklandrpwq", "mnptpzjcmdzdggcz", "zxnhcplckvwezgnkjz", "vqwvkpdzohttsyytpng", "dmwijzjurllszybvm", "zsympfot", "qmzzsanbuplvejtwbqtg", "tezvuepqsmraqxfwnqr", "itxasnhwops", "hrdfzgnxbeknef", "okzrqwwmfrlvbubnjw", "bwahvgnotav", "cyduoedgzhdxttz", "dyuyee", "yjvoohtluvrxnlifql", "kglpoyyuemxgfi", "wzfxrqgxjxawek", "uxyviphlotnle", "hjogkmrdtcmzmgsfkh", "upmbaqcocttdx", "fhfdzylsbqiafm", "pdyxtytn", "comswxfkxfj", "xabxgiyfkmnflhjh", "nslqwrq", "oljpq", "ssqowqmb", "fcigcoxbq", "loqevfbbkifwsedchpq", "rgubwgdcrinal", "tidasdjoklf", "wwpcjbfxqfizjpzol", "zspdjdpgekkacgctkvwh", "pltzkbwml", "zvbzqfm", "lqfonvcbboii", "kusyrpw", "lzgzakr", "oudfnnnwmlryis", "yjwjemmqg", "mtamsirdvnppqaaydkx", "nxxbjngheqt", "hnbqxllcfosluzhaqg", "hvyvrhuqhyuhapimdy", "fbzpjs", "ekqdfgcthakh", "iiqxr", "ueonkxk", "hqhmwwmaanqkghlathfa", "dfrmncqjg", "rzlkkoizkd", "ltuuaizrq", "evdwlr", "juxmjkmvrbahzs", "qtixleaahxktcmxz", "bnjthutptwgt", "cemhtagguwfrw", "gkdzlulrcg", "kvpyzznj", "hekwplrlfjsm", "bcgchr", "taljqf", "wjazxtqfgtjqhs", "ounugclabpxnlxsxkg", "mlqrvfvkplrtqvhbzash", "nggcqcaxqtx", "xthfdm", "bwafqimqwdiwmbgcvv", "bzbafrrzrmtynjyemwye", "wylhkvzxuacdfcfd", "qrlgomrknwd", "gkaepgbabcynnlns", "fciexuohnzzngzk", "brewbzxvbje", "rxnkckz", "osylsd", "zpjqpqkmpqacbnansg", "xubljwbydai", "jfjuyqchyhhxgjltlqxu", "ziwmt", "lygelxhzihxiorkeed", "gkqbtl", "oniiwfy", "emtaidkqcvm", "wnypwygoxyothth", "fcdznjuhudjvqnlxukg", "bboakejurrydr", "dhknnkrdoydrx", "cvlwckqkyzt", "polbapsncnetp", "qllzukgywcgedodzg", "thvvwbchfvatdlf", "mtcuviprdhh", "gehgyukrsdvycw", "tznulai", "kpknlcdzevo", "stvtcmipneyor", "xlljiukcwbacntwaoie", "pzvyphgrt", "fydqmphs", "vbscukusyfhiqpkmdyz", "swqwmchzamyhgftmrvz", "hrxiwqunlgqb", "atsncc", "umcqnn", "kvgmkybxhueu", "yrztjmsvagkmo", "etutg", "ycbmvm", "nbopeblpvatugtg", "zhbtqmsbubpfomaxfu", "lyimzqq", "ywimavjcdwbo", "hpsklqmsmfjtargdjvgs", "itowxyizzxqlrniv", "awujjdhzlsawrpdvn", "mvyyhjjgfktxerwmwt", "apwpnbydbrjs", "eqfhmrqynclfjalxdfqa", "syvzdrllukyvzbsyxe", "pwempqjk" };
        //private string[] DestStringArray2;

        public class MyClass
        {

        }


        //public class CategoryOrderer : IOrderer
        //{
        //    public bool SeparateLogicalGroups => true;

        //    public IEnumerable<BenchmarkCase> GetExecutionOrder(ImmutableArray<BenchmarkCase> benchmarksCase)
        //    {
        //        return from benchmark in benchmarksCase
        //               orderby benchmark.
        //    }

        //    public string GetHighlightGroupKey(BenchmarkCase benchmarkCase)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public string GetLogicalGroupKey(ImmutableArray<BenchmarkCase> allBenchmarksCases, BenchmarkCase benchmarkCase)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public IEnumerable<IGrouping<string, BenchmarkCase>> GetLogicalGroupOrder(IEnumerable<IGrouping<string, BenchmarkCase>> logicalGroups)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public IEnumerable<BenchmarkCase> GetSummaryOrder(ImmutableArray<BenchmarkCase> benchmarksCases, Summary summary)
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        ////internal static BigInteger Src = new BigInteger();

        ////internal unsafe ref struct BigInteger
        ////{
        ////    private const int MaxBlockCount = 20;

        ////    private fixed uint _blocks[MaxBlockCount];

        ////    public BigInteger 
        ////}

        public const long RandomSeed = 221;

        [ParamsSource(nameof(ValuesForArrayLength))]
        public int ArrayLength { get; set; }
        public IEnumerable<int> ValuesForArrayLength => new[] { 8, 56, 1022 };

        public static byte[] ByteArray;
        public static byte[] DestByteArray;

        public static int[] Int32Array;
        public static int[] DestInt32Array;

        public static long[] Int64Array;
        public static long[] DestInt64Array;

        public static char[] CharArray;
        public static char[] DestCharArray;

        public static string[] StringArray;
        public static string[] DestStringArray;

        public static MyClass[] ObjectArray;
        public static MyClass[] DestObjectArray;

        //public int ShortArrayLength = 8;
        //public int MediumArrayLength = 56;
        //public int LongArrayLength = 1022;

        //public static byte[] ByteArray_Short;
        //public static byte[] ByteArray_Medium;
        //public static byte[] ByteArray_Long;
        //public static byte[] DestByteArray_Short;
        //public static byte[] DestByteArray_Medium;
        //public static byte[] DestByteArray_Long;

        //public static int[] Int32Array_Short;
        //public static int[] Int32Array_Medium;
        //public static int[] Int32Array_Long;
        //public static int[] DestInt32Array_Short;
        //public static int[] DestInt32Array_Medium;
        //public static int[] DestInt32Array_Long;

        //public static long[] Int64Array_Short;
        //public static long[] Int64Array_Medium;
        //public static long[] Int64Array_Long;
        //public static long[] DestInt64Array_Short;
        //public static long[] DestInt64Array_Medium;
        //public static long[] DestInt64Array_Long;

        //public static char[] CharArray_Short;
        //public static char[] CharArray_Medium;
        //public static char[] CharArray_Long;
        //public static char[] DestCharArray_Short;
        //public static char[] DestCharArray_Medium;
        //public static char[] DestCharArray_Long;

        //public static string[] StringArray_Short;
        //public static string[] StringArray_Medium;
        //public static string[] StringArray_Long;
        //public static string[] DestStringArray_Short;
        //public static string[] DestStringArray_Medium;
        //public static string[] DestStringArray_Long;

        //public static MyClass[] ObjectArray_Short;
        //public static MyClass[] ObjectArray_Medium;
        //public static MyClass[] ObjectArray_Long;
        //public static MyClass[] DestObjectArray_Short;
        //public static MyClass[] DestObjectArray_Medium;
        //public static MyClass[] DestObjectArray_Long;



        //[GlobalSetup]
        //public void GlobalSetup()
        //{
        //    ByteArray_Short = new byte[ShortArrayLength];
        //    ByteArray_Medium = new byte[MediumArrayLength];
        //    ByteArray_Long = new byte[LongArrayLength];

        //    Int32Array_Short = new int[ShortArrayLength];
        //    Int32Array_Medium = new int[MediumArrayLength];
        //    Int32Array_Long = new int[LongArrayLength];

        //    Int64Array_Short = new long[ShortArrayLength];
        //    Int64Array_Medium = new long[MediumArrayLength];
        //    Int64Array_Long = new long[LongArrayLength];

        //    CharArray_Short = new char[ShortArrayLength];
        //    CharArray_Medium = new char[MediumArrayLength];
        //    CharArray_Long = new char[LongArrayLength];

        //    StringArray_Short = new string[ShortArrayLength];
        //    StringArray_Medium = new string[MediumArrayLength];
        //    StringArray_Long = new string[LongArrayLength];

        //    ObjectArray_Short = new MyClass[ShortArrayLength];
        //    ObjectArray_Medium = new MyClass[MediumArrayLength];
        //    ObjectArray_Long = new MyClass[LongArrayLength];


        //    var random = new Randomizer(RandomSeed);
        //    for (int s = 0; s < ShortArrayLength; s++)
        //    {
        //        ByteArray_Short[s] = (byte)random.NextInt32(byte.MinValue, byte.MaxValue);
        //        Int32Array_Short[s] = random.NextInt32(int.MinValue, int.MaxValue);
        //        Int64Array_Short[s] = random.NextInt64(long.MinValue, long.MaxValue);
        //        CharArray_Short[s] = (char)random.NextInt32(char.MinValue, char.MaxValue);
        //        StringArray_Short[s] = random.NextRealisticUnicodeString(5, 120);
        //        ObjectArray_Short[s] = new MyClass();
        //    }

        //    for (int s = 0; s < MediumArrayLength; s++)
        //    {
        //        ByteArray_Medium[s] = (byte)random.NextInt32(byte.MinValue, byte.MaxValue);
        //        Int32Array_Medium[s] = random.NextInt32(int.MinValue, int.MaxValue);
        //        Int64Array_Medium[s] = random.NextInt64(long.MinValue, long.MaxValue);
        //        CharArray_Medium[s] = (char)random.NextInt32(char.MinValue, char.MaxValue);
        //        StringArray_Medium[s] = random.NextRealisticUnicodeString(5, 120);
        //        ObjectArray_Medium[s] = new MyClass();
        //    }

        //    for (int s = 0; s < LongArrayLength; s++)
        //    {
        //        ByteArray_Long[s] = (byte)random.NextInt32(byte.MinValue, byte.MaxValue);
        //        Int32Array_Long[s] = random.NextInt32(int.MinValue, int.MaxValue);
        //        Int64Array_Long[s] = random.NextInt64(long.MinValue, long.MaxValue);
        //        CharArray_Long[s] = (char)random.NextInt32(char.MinValue, char.MaxValue);
        //        StringArray_Long[s] = random.NextRealisticUnicodeString(5, 120);
        //        ObjectArray_Long[s] = new MyClass();
        //    }
        //}

        [IterationSetup]
        public void IterationSetup()
        {
            //DestByteArray1 = new byte[ByteArray2.Length];
            //DestInt32Array1 = new int[Int32Array2.Length];
            //DestInt64Array2 = new long[Int64Array2.Length];
            //DestCharArray2 = new char[CharArray2.Length];
            //DestObjArray2 = new MyClass[ObjArray2.Length];
            //DestStringArray2 = new string[StringArray2.Length];

            ByteArray = new byte[ArrayLength];
            DestByteArray = new byte[ArrayLength];

            Int32Array = new int[ArrayLength];
            DestInt32Array = new int[ArrayLength];

            Int64Array = new long[ArrayLength];
            DestInt64Array = new long[ArrayLength];

            CharArray = new char[ArrayLength];
            DestCharArray = new char[ArrayLength];

            StringArray = new string[ArrayLength];
            DestStringArray = new string[ArrayLength];

            ObjectArray = new MyClass[ArrayLength];
            DestObjectArray = new MyClass[ArrayLength];

            var random = new Randomizer(RandomSeed);
            for (int i = 0; i < ArrayLength; i++)
            {
                ByteArray[i] = (byte)random.NextInt32(byte.MinValue, byte.MaxValue);
                Int32Array[i] = random.NextInt32(0, 999999);
                Int64Array[i] = random.NextInt64(0, 999999);
                CharArray[i] = (char)random.NextInt32(char.MinValue, char.MaxValue);
                StringArray[i] = random.NextRealisticUnicodeString(5, 120);
                ObjectArray[i] = new MyClass();
            }
            //DestByteArray_Short = new byte[ShortArrayLength];
            //DestByteArray_Medium = new byte[MediumArrayLength];
            //DestByteArray_Long = new byte[LongArrayLength];

            //DestInt32Array_Short = new int[ShortArrayLength];
            //DestInt32Array_Medium = new int[MediumArrayLength];
            //DestInt32Array_Long = new int[LongArrayLength];

            //DestInt64Array_Short = new long[ShortArrayLength];
            //DestInt64Array_Medium = new long[MediumArrayLength];
            //DestInt64Array_Long = new long[LongArrayLength];

            //DestCharArray_Short = new char[ShortArrayLength];
            //DestCharArray_Medium = new char[MediumArrayLength];
            //DestCharArray_Long = new char[LongArrayLength];

            //DestStringArray_Short = new string[ShortArrayLength];
            //DestStringArray_Medium = new string[MediumArrayLength];
            //DestStringArray_Long = new string[LongArrayLength];

            //DestObjectArray_Short = new MyClass[ShortArrayLength];
            //DestObjectArray_Medium = new MyClass[MediumArrayLength];
            //DestObjectArray_Long = new MyClass[LongArrayLength];
        }

        ////[Benchmark]
        ////public int ByteArray1_GetHashCode() => Arrays.GetHashCode(ByteArray1);

        ////[Benchmark]
        ////public int ByteArray1_GetHashCode2() => Arrays.GetHashCode2(ByteArray1);


        //[Benchmark]
        //public void ArrayIterate_Index()
        //{
        //    int byteArray2Length = ByteArray2.Length;
        //    for (int i = 0; i < Iterations; i++)
        //    {
        //        for (int j = 0; j < byteArray2Length; j++)
        //        {
        //            byte element = ByteArray2[j];
        //        }
        //    }
        //}

        //[Benchmark]
        //public void ArrayIterate_Enumerator()
        //{
        //    for (int i = 0; i < Iterations; i++)
        //    {
        //        foreach (byte element in ByteArray2)
        //        {

        //        }
        //    }
        //}

        //[Benchmark]
        //public unsafe void ArrayIterate_Pointer_Indexed()
        //{
        //    int byteArray2Length = ByteArray2.Length;
        //    fixed (byte* bytes = &ByteArray2[0])
        //    {
        //        for (int i = 0; i < Iterations; i++)
        //        {
        //            for (int j = 0; j < byteArray2Length; j++)
        //            {
        //                byte element = bytes[j];
        //            }
        //        }
        //    }
        //}

        //[Benchmark]
        //public unsafe void ArrayIterate_Pointer_Incremented()
        //{
        //    int byteArray2Length = ByteArray2.Length;
        //    fixed (byte* bytes = &ByteArray2[0])
        //    {
        //        byte* byteArray2;
        //        for (int i = 0; i < Iterations; i++)
        //        {
        //            byteArray2 = bytes;
        //            for (int j = 0; j < byteArray2Length; j++)
        //            {
        //                byte element = *byteArray2++;
        //            }
        //        }
        //    }
        //}

        ////[Benchmark]
        ////public void Benchmark_ArrayCopy_BufferMemoryCopy()
        ////{
        ////    for(int i = 0; i < Iterations; i++)
        ////    { 
        ////        unsafe
        ////        {
        ////            fixed (byte* srcPtr = &ByteArray1[0], destPtr = &DestByteArray1[0])
        ////            {
        ////                byte* dest = destPtr;
        ////                byte* src = srcPtr;
        ////                Buffer.MemoryCopy(src, dest, DestByteArray1.Length, ByteArray1.Length);
        ////            }
        ////        }
        ////    }
        ////}

        ////[Benchmark]
        ////public void Benchmark_ArrayCopy_MarshalCopy()
        ////{
        ////    for (int i = 0; i < Iterations; i++)
        ////    {
        ////        unsafe
        ////        {
        ////            fixed (byte* srcPtr = &ByteArray1[0], destPtr = &DestByteArray1[0])
        ////            {
        ////                byte* src = srcPtr;
        ////                Marshal.Copy()
        ////                Buffer.MemoryCopy(src, dest, DestByteArray1.Length, ByteArray1.Length);
        ////            }
        ////        }
        ////    }
        ////}

        //[Benchmark]
        //public void ArrayIterate_Span()
        //{
        //    for (int i = 0; i < Iterations; i++)
        //    {
        //        foreach (byte element in ByteArray2.AsSpan())
        //        {

        //        }
        //    }
        //}


        // byte

        [Benchmark]
        [BenchmarkCategory("Byte")]
        public void ArrayCopy_Byte_Span_Copy()
        {
            for (int i = 0; i < Iterations; i++)
            {
                ByteArray.AsSpan().CopyTo(DestByteArray.AsSpan());
            }
        }

        [Benchmark]
        [BenchmarkCategory("Byte")]
        public void ArrayCopy_Byte_Memory_Copy()
        {
            for (int i = 0; i < Iterations; i++)
            {
                ByteArray.AsMemory().CopyTo(DestByteArray.AsMemory());
            }
        }

        [Benchmark]
        [BenchmarkCategory("Byte")]
        public void ArrayCopy_Byte_Array_Copy()
        {
            for (int i = 0; i < Iterations; i++)
            {
                Array.Copy(ByteArray, 0, DestByteArray, 0, ByteArray.Length);
            }
        }

        [Benchmark]
        [BenchmarkCategory("Byte")]
        public void ArrayCopy_Byte_Buffer_BlockCopy()
        {
            for (int i = 0; i < Iterations; i++)
            {
                Buffer.BlockCopy(ByteArray, 0, DestByteArray, 0, ByteArray.Length);
            }
        }

        [Benchmark]
        [BenchmarkCategory("Byte")]
        public void ArrayCopy_Byte_Buffer_MemoryCopy()
        {
            for (int i = 0; i < Iterations; i++)
            {
                unsafe
                {
                    fixed (byte* srcPtr = &ByteArray[0], destPtr = &DestByteArray[0])
                    {
                        byte* dest = destPtr;
                        byte* src = srcPtr;
                        Buffer.MemoryCopy(src, dest, DestByteArray.Length, ByteArray.Length);
                    }
                }
            }
        }

        // int

        [Benchmark]
        [BenchmarkCategory("Int32")]
        public void ArrayCopy_Int32_Span_Copy()
        {
            for (int i = 0; i < Iterations; i++)
            {
                Int32Array.AsSpan().CopyTo(DestInt32Array.AsSpan());
            }
        }

        [Benchmark]
        [BenchmarkCategory("Int32")]
        public void ArrayCopy_Int32_Memory_Copy()
        {
            for (int i = 0; i < Iterations; i++)
            {
                Int32Array.AsMemory().CopyTo(DestInt32Array.AsMemory());
            }
        }

        [Benchmark]
        [BenchmarkCategory("Int32")]
        public void ArrayCopy_Int32_Array_Copy()
        {
            for (int i = 0; i < Iterations; i++)
            {
                Array.Copy(Int32Array, 0, DestInt32Array, 0, Int32Array.Length);
            }
        }

        [Benchmark]
        [BenchmarkCategory("Int32")]
        public void ArrayCopy_Int32_Buffer_BlockCopy()
        {
            for (int i = 0; i < Iterations; i++)
            {
                Buffer.BlockCopy(Int32Array, 0, DestInt32Array, 0, Int32Array.Length * sizeof(int));
            }
        }

        [Benchmark]
        [BenchmarkCategory("Int32")]
        public void ArrayCopy_Int32_Buffer_MemoryCopy()
        {
            for (int i = 0; i < Iterations; i++)
            {
                unsafe
                {
                    fixed (int* srcPtr = &Int32Array[0], destPtr = &DestInt32Array[0])
                    {
                        int* dest = destPtr;
                        int* src = srcPtr;
                        long byteLength = Int32Array.Length * sizeof(int);
                        Buffer.MemoryCopy(src, dest, byteLength, byteLength);
                    }
                }
            }
        }

        // long

        [Benchmark]
        [BenchmarkCategory("Int64")]
        public void ArrayCopy_Int64_Span_Copy()
        {
            for (int i = 0; i < Iterations; i++)
            {
                Int64Array.AsSpan().CopyTo(DestInt64Array.AsSpan());
            }
        }

        [Benchmark]
        [BenchmarkCategory("Int64")]
        public void ArrayCopy_Int64_Memory_Copy()
        {
            for (int i = 0; i < Iterations; i++)
            {
                Int64Array.AsMemory().CopyTo(DestInt64Array.AsMemory());
            }
        }

        [Benchmark]
        [BenchmarkCategory("Int64")]
        public void ArrayCopy_Int64_Array_Copy()
        {
            for (int i = 0; i < Iterations; i++)
            {
                Array.Copy(Int64Array, 0, DestInt64Array, 0, Int64Array.Length);
            }
        }

        [Benchmark]
        [BenchmarkCategory("Int64")]
        public void ArrayCopy_Int64_Buffer_BlockCopy()
        {
            for (int i = 0; i < Iterations; i++)
            {
                Buffer.BlockCopy(Int64Array, 0, DestInt64Array, 0, Int64Array.Length * sizeof(long));
            }
        }

        // Doubt this works on 32 bit
        //[Benchmark]
        //public void ArrayCopy_Int64_Buffer_MemoryCopy()
        //{
        //    for (int i = 0; i < Iterations; i++)
        //    {
        //        unsafe
        //        {
        //            fixed (long* srcPtr = &Int64Array[0], destPtr = &DestInt64Array[0])
        //            {
        //                byte* dest = destPtr;
        //                byte* src = srcPtr;
        //                long byteLength = Int64Array.Length * sizeof(long);
        //                Buffer.MemoryCopy(src, dest, byteLength, byteLength);
        //            }
        //        }
        //    }
        //}

        // char

        [Benchmark]
        [BenchmarkCategory("Span")]
        public void ArrayCopy_Char_Span_Copy()
        {
            for (int i = 0; i < Iterations; i++)
            {
                CharArray.AsSpan().CopyTo(DestCharArray.AsSpan());
            }
        }

        [Benchmark]
        [BenchmarkCategory("Span")]
        public void ArrayCopy_Char_Memory_Copy()
        {
            for (int i = 0; i < Iterations; i++)
            {
                CharArray.AsMemory().CopyTo(DestCharArray.AsMemory());
            }
        }

        [Benchmark]
        [BenchmarkCategory("Span")]
        public void ArrayCopy_Char_Array_Copy()
        {
            for (int i = 0; i < Iterations; i++)
            {
                Array.Copy(CharArray, 0, DestCharArray, 0, CharArray.Length);
            }
        }

        [Benchmark]
        [BenchmarkCategory("Span")]
        public void ArrayCopy_Char_Buffer_BlockCopy()
        {
            for (int i = 0; i < Iterations; i++)
            {
                Buffer.BlockCopy(CharArray, 0, DestCharArray, 0, CharArray.Length * sizeof(char));
            }
        }

        //[Benchmark]
        //public void ArrayCopy_Int32_Buffer_MemoryCopy()
        //{
        //    for (int i = 0; i < Iterations; i++)
        //    {
        //        unsafe
        //        {
        //            fixed (byte* srcPtr = (byte*)&CharArray[0], destPtr = &DestCharArray[0])
        //            {
        //                byte* dest = destPtr;
        //                byte* src = srcPtr;
        //                long byteLength = CharArray.Length * sizeof(char);
        //                Buffer.MemoryCopy(src, dest, byteLength, byteLength);
        //            }
        //        }
        //    }
        //}


        // string
#if !NETFRAMEWORK
        [Benchmark]
        [BenchmarkCategory("String")]
        public void ArrayCopy_String_Span_Copy()
        {
            for (int i = 0; i < Iterations; i++)
            {
                StringArray.AsSpan().CopyTo(DestStringArray.AsSpan());
            }
        }

        [Benchmark]
        [BenchmarkCategory("String")]
        public void ArrayCopy_String_Memory_Copy()
        {
            for (int i = 0; i < Iterations; i++)
            {
                StringArray.AsMemory().CopyTo(DestStringArray.AsMemory());
            }
        }
#endif

        [Benchmark]
        [BenchmarkCategory("String")]
        public void ArrayCopy_String_Array_Copy()
        {
            for (int i = 0; i < Iterations; i++)
            {
                Array.Copy(StringArray, 0, DestStringArray, 0, StringArray.Length);
            }
        }

        //[Benchmark]
        //public void ArrayCopy_String_Buffer_BlockCopy()
        //{
        //    for (int i = 0; i < Iterations; i++)
        //    {
        //        Buffer.BlockCopy(StringArray, 0, DestStringArray, 0, StringArray.Length * sizeof(string));
        //    }
        //}

        //[Benchmark]
        //public void ArrayCopy_String_Buffer_MemoryCopy()
        //{
        //    for (int i = 0; i < Iterations; i++)
        //    {
        //        unsafe
        //        {
        //            fixed (byte* srcPtr = (byte*)&StringArray[0], destPtr = &DestStringArray[0])
        //            {
        //                byte* dest = destPtr;
        //                byte* src = srcPtr;
        //                Buffer.MemoryCopy(src, dest, DestStringArray.Length * sizeof(string), StringArray.Length * sizeof(string));
        //            }
        //        }
        //    }
        //}

        //[Benchmark]
        //public void ArrayCopy_String_ForLoop()
        //{
        //    for (int i = 0; i < Iterations; i++)
        //    {
        //        for (int j = 0; j < StringArray2.Length; j++)
        //        {
        //            DestStringArray[j] = StringArray2[j];
        //        }
        //    }
        //}


        // object

#if !NETFRAMEWORK
        [Benchmark]
        [BenchmarkCategory("Object")]
        public void ArrayCopy_Object_Span_Copy()
        {
            for (int i = 0; i < Iterations; i++)
            {
                ObjectArray.AsSpan().CopyTo(DestObjectArray.AsSpan());
            }
        }

        [Benchmark]
        [BenchmarkCategory("Object")]
        public void ArrayCopy_Object_Memory_Copy()
        {
            for (int i = 0; i < Iterations; i++)
            {
                ObjectArray.AsMemory().CopyTo(DestObjectArray.AsMemory());
            }
        }
#endif

        [Benchmark]
        [BenchmarkCategory("Object")]
        public void ArrayCopy_Obj_Array_Copy()
        {
            for (int i = 0; i < Iterations; i++)
            {
                Array.Copy(ObjectArray, 0, DestObjectArray, 0, ObjectArray.Length);
            }
        }

        //[Benchmark]
        //public void ArrayCopy_Obj_Buffer_BlockCopy()
        //{
        //    for (int i = 0; i < Iterations; i++)
        //    {
        //        Buffer.BlockCopy(ObjectArray, 0, DestObjectArray, 0, ObjectArray.Length * sizeof(MyClass));
        //    }
        //}

        //[Benchmark]
        //public void ArrayCopy_Int32_Buffer_MemoryCopy()
        //{
        //    for (int i = 0; i < Iterations; i++)
        //    {
        //        unsafe
        //        {
        //            fixed (byte* srcPtr = (byte*)&ObjectArray[0], destPtr = &DestObjectArray[0])
        //            {
        //                byte* dest = destPtr;
        //                byte* src = srcPtr;
        //                Buffer.MemoryCopy(src, dest, DestObjectArray.Length * sizeof(MyClass), ObjectArray.Length * sizeof(MyClass));
        //            }
        //        }
        //    }
        //}

        //[Benchmark]
        //public void ArrayCopy_Obj_ForLoop()
        //{
        //    for (int i = 0; i < Iterations; i++)
        //    {
        //        for (int j = 0; j < ObjArray2.Length; j++)
        //        {
        //            DestObjArray2[j] = ObjArray2[j];
        //        }
        //    }
        //}



        // Fastest speeds

        // For byte:

        // net461: ArrayCopy_BufferMemoryCopy (followed by ArrayCopy_Span)
        // net6.0: ArrayCopy_Span

        // For int:

        // net461: ArrayCopy_Int32_Array_Copy
        // net6.0: ArrayCopy_Int32_Span

        // For long:

        // net461: ArrayCopy_Int64_Buffer_BlockCopy (followed by Span and ArrayCopy - a tie)
        // net6.0: ArrayCopy_Int64_Span

        // For char:

        // net461: ArrayCopy_Char_Span (followed by ArrayCopy_Char_Array_Copy)
        // net6.0: ArrayCopy_Char_Span (followed by ArrayCopy_Char_Array_Copy)

        // For object:

        // net461: ArrayCopy_Obj_Array_Copy (Span/Memory are horribly slow)
        // net6.0: ArrayCopy_Obj_Memory (followed by ArrayCopy_Obj_Span, but only a slight variation between all 3)
    }


}
