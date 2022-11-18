using BenchmarkDotNet.Attributes;
//using J2N.Numerics;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace BenchmarkPlayground
{
    [MemoryDiagnoser]
    [MediumRunJob]
    public class BenchmarkArrays
    {
        public const int Iterations = 100000;

        public static readonly byte[] ByteArray1 = new byte[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
        public static readonly byte[] ByteArray1_Equal = new byte[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
        public static readonly byte[] ByteArray1_NotEqual = new byte[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 2 };


        public static readonly byte[] ByteArray2 = new byte[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };

        private byte[] DestByteArray1;


        public static readonly int[] Int32Array2 = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };

        private int[] DestInt32Array1;

        public static readonly long[] Int64Array2 = new long[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };

        private long[] DestInt64Array2;

        public static readonly char[] CharArray2 = new char[] { (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0, (char)9, (char)8, (char)7, (char)6, (char)5, (char)4, (char)3, (char)2, (char)1, (char)0 };
        private char[] DestCharArray2;

        public static readonly MyClass[] ObjArray2 = new MyClass[] { new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass(), new MyClass() };
        private MyClass[] DestObjArray2;


        public static readonly string[] StringArray2 = new string[] { "cybvmnywh", "byerjxqqjstmw", "yldpbdfkgzbnekujl", "vzmbk", "eojzgijavearoxbp", "ljewtfw", "ghgsjpakqltl", "pvyskuebe", "ipanadtxelrbfnzslnf", "qdjct", "gsqhsqfbn", "fydugatjjn", "rrpjknvqwpwnochz", "eonuqntusbdxmp", "vbafqe", "bvfuvzovr", "pgjwqiwwvpyet", "ugqbajbur", "zjvrmpi", "xipbh", "quqnugjx", "zwubypoimyqz", "fpnpvpgybwaiz", "rzrtp", "ktyhtrthvib", "fdasoyamsvfwpqrfwhp", "ziespbnd", "gzcaxyeupnnjkrurwma", "kdzyrphrmnfsgit", "qkvslzbjbpodrfrb", "avrtye", "ougyksl", "lqvvpwrfiohqococsx", "puzvphmwefgnz", "dplmbzjfrnfbtwuwzs", "qvpsgqudarftgzsljuh", "kjtiyydudvf", "wlkswvgsyqb", "navsr", "njekqiwhnmzllksjmy", "kzhdmvybzyclenar", "egosdlpqyl", "xbmsqids", "yephnsgn", "umyuwv", "khtaae", "smqtgfhjgt", "zsnffjdqvpjxgjyaajl", "bciolrddn", "oeiuvlxc", "npwhidpbqgvzwzdnaa", "cigsmx", "zjvripdslasinax", "qsaez", "ejfejbhrxjxrygtni", "fpgainvhbntn", "dauugbhtvyjuwybf", "rzkdaa", "wgewoqjambputgzkhrsn", "oeiiacjckjq", "xyiqkbucokchoaq", "gcswfgtwpirax", "eefdeazyynufuxjh", "dpwaszjgtrlweqn", "gakgum", "temaqom", "teoqfg", "qjoqphlqnew", "dtbkdyjwl", "mnllhkvtum", "vmawspphpnu", "znnfwiwyqoqooiz", "qixdppvmyjmabdx", "qeqitmypreufurxuu", "jhlnnqbc", "kketmmuabvsnwfsgr", "pvzxqioa", "tbpgjxm", "dcjbvci", "cdpkhyldvcwxuxcz", "jdgckdx", "uglqsyuopceervzvm", "dkhlhmftm", "ugexzhk", "njlpavulclbw", "jatzimdqpmysvuakvsvo", "phbhjfcsrcihjsa", "qbksgufgyxnvvex", "nykcm", "hwolifv", "bfsgc", "outhcwewggjhjdszjxcl", "oedgxprfzmye", "awnelfthqwfo", "fbbapcvfwrshrtum", "bnjndnoolqajkxuhhq", "arckzonz", "cdqma", "weuxjameknrz", "cmsdlhbowbpqcizwujy", "yhhgqpzzs", "kzexr", "gqdsylnyoyuciu", "txvzhv", "womnsxu", "pejisqtbdkdt", "saphqxqvg", "mysxzmonpqscsamnf", "wnfiki", "uhjowuznsm", "ayogpupcpkukgfpusj", "rxjgboekbyenk", "imklpwfbwdujzrohji", "ldnuovwxohx", "aztkjjiuks", "aystshfmzmvxirih", "dskihvz", "xqzivrnmevpeuwi", "xvylzxxduftaxeq", "dmmgsndpttsucxgozo", "xygdjqtsquecoaxzt", "ocyue", "qtdpmabst", "ntetzsutim", "krldgpo", "chzaw", "frtlxvg", "kdwrzkpewaqgujlor", "mrhpcnfk", "qdciwen", "ionqyjcvad", "yvrghwblhjxqcosmuwz", "ajlnmdhzpeotufkdort", "dogcoxhzwcniugpm", "vhilcqdm", "euqdgoyymdgywck", "geaynmuhzg", "idwbsroqjs", "zexjtfd", "yyugfges", "hrigxyyeudyathxnq", "zrwjolfhxtdfwpbvovcg", "fimkcbwfkkpuauurqz", "ogjpvdzjfa", "alxmczdjfxqn", "kpwhajuolp", "takfzfzbnmxyhq", "qfxmlxohxufcfzpj", "eppmnm", "wztchbwhmyr", "axocbwghaikzihsxsxgp", "wqatto", "twtficibxburxkkp", "xaacfqflvo", "ohkqmyymgkyz", "crvmrkvotxqch", "aaiivn", "lcoqsxstcawq", "namjc", "xxckyyo", "znmmssisexywirdaeds", "fbfgkurt", "fwpxkpxsqohrzn", "kdmtjckftpglamx", "eylcylkvgox", "emdtvtfggytb", "gpwynacgrpwrbk", "uycuttfmsgwvq", "yvbfngsqiexi", "dkwpyubgbuklandrpwq", "mnptpzjcmdzdggcz", "zxnhcplckvwezgnkjz", "vqwvkpdzohttsyytpng", "dmwijzjurllszybvm", "zsympfot", "qmzzsanbuplvejtwbqtg", "tezvuepqsmraqxfwnqr", "itxasnhwops", "hrdfzgnxbeknef", "okzrqwwmfrlvbubnjw", "bwahvgnotav", "cyduoedgzhdxttz", "dyuyee", "yjvoohtluvrxnlifql", "kglpoyyuemxgfi", "wzfxrqgxjxawek", "uxyviphlotnle", "hjogkmrdtcmzmgsfkh", "upmbaqcocttdx", "fhfdzylsbqiafm", "pdyxtytn", "comswxfkxfj", "xabxgiyfkmnflhjh", "nslqwrq", "oljpq", "ssqowqmb", "fcigcoxbq", "loqevfbbkifwsedchpq", "rgubwgdcrinal", "tidasdjoklf", "wwpcjbfxqfizjpzol", "zspdjdpgekkacgctkvwh", "pltzkbwml", "zvbzqfm", "lqfonvcbboii", "kusyrpw", "lzgzakr", "oudfnnnwmlryis", "yjwjemmqg", "mtamsirdvnppqaaydkx", "nxxbjngheqt", "hnbqxllcfosluzhaqg", "hvyvrhuqhyuhapimdy", "fbzpjs", "ekqdfgcthakh", "iiqxr", "ueonkxk", "hqhmwwmaanqkghlathfa", "dfrmncqjg", "rzlkkoizkd", "ltuuaizrq", "evdwlr", "juxmjkmvrbahzs", "qtixleaahxktcmxz", "bnjthutptwgt", "cemhtagguwfrw", "gkdzlulrcg", "kvpyzznj", "hekwplrlfjsm", "bcgchr", "taljqf", "wjazxtqfgtjqhs", "ounugclabpxnlxsxkg", "mlqrvfvkplrtqvhbzash", "nggcqcaxqtx", "xthfdm", "bwafqimqwdiwmbgcvv", "bzbafrrzrmtynjyemwye", "wylhkvzxuacdfcfd", "qrlgomrknwd", "gkaepgbabcynnlns", "fciexuohnzzngzk", "brewbzxvbje", "rxnkckz", "osylsd", "zpjqpqkmpqacbnansg", "xubljwbydai", "jfjuyqchyhhxgjltlqxu", "ziwmt", "lygelxhzihxiorkeed", "gkqbtl", "oniiwfy", "emtaidkqcvm", "wnypwygoxyothth", "fcdznjuhudjvqnlxukg", "bboakejurrydr", "dhknnkrdoydrx", "cvlwckqkyzt", "polbapsncnetp", "qllzukgywcgedodzg", "thvvwbchfvatdlf", "mtcuviprdhh", "gehgyukrsdvycw", "tznulai", "kpknlcdzevo", "stvtcmipneyor", "xlljiukcwbacntwaoie", "pzvyphgrt", "fydqmphs", "vbscukusyfhiqpkmdyz", "swqwmchzamyhgftmrvz", "hrxiwqunlgqb", "atsncc", "umcqnn", "kvgmkybxhueu", "yrztjmsvagkmo", "etutg", "ycbmvm", "nbopeblpvatugtg", "zhbtqmsbubpfomaxfu", "lyimzqq", "ywimavjcdwbo", "hpsklqmsmfjtargdjvgs", "itowxyizzxqlrniv", "awujjdhzlsawrpdvn", "mvyyhjjgfktxerwmwt", "apwpnbydbrjs", "eqfhmrqynclfjalxdfqa", "syvzdrllukyvzbsyxe", "pwempqjk" };
        private string[] DestStringArray2;

        public class MyClass
        {

        }

        ////internal static BigInteger Src = new BigInteger();

        ////internal unsafe ref struct BigInteger
        ////{
        ////    private const int MaxBlockCount = 20;

        ////    private fixed uint _blocks[MaxBlockCount];

        ////    public BigInteger 
        ////}

        [IterationSetup]
        public void IterationSetup()
        {
            DestByteArray1 = new byte[ByteArray2.Length];
            DestInt32Array1 = new int[Int32Array2.Length];
            DestInt64Array2 = new long[Int64Array2.Length];
            DestCharArray2 = new char[CharArray2.Length];
            DestObjArray2 = new MyClass[ObjArray2.Length];
            DestStringArray2 = new string[StringArray2.Length];
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

        //[Benchmark]
        //public void ArrayCopy_Span()
        //{
        //    for (int i = 0; i < Iterations; i++)
        //    {
        //        ByteArray2.AsSpan().CopyTo(DestByteArray1.AsSpan());
        //    }
        //}

        //[Benchmark]
        //public void ArrayCopy_Memory()
        //{
        //    for (int i = 0; i < Iterations; i++)
        //    {
        //        ByteArray2.AsMemory().CopyTo(DestByteArray1.AsMemory());
        //    }
        //}

        //[Benchmark]
        //public void ArrayCopy_Array_Copy()
        //{
        //    for (int i = 0; i < Iterations; i++)
        //    {
        //        Array.Copy(ByteArray2, 0, DestByteArray1, 0, ByteArray2.Length);
        //    }
        //}

        //[Benchmark]
        //public void ArrayCopy_Block_Copy()
        //{
        //    for (int i = 0; i < Iterations; i++)
        //    {
        //        Buffer.BlockCopy(ByteArray2, 0, DestByteArray1, 0, ByteArray2.Length);
        //    }
        //}

        //[Benchmark]
        //public void ArrayCopy_BufferMemoryCopy()
        //{
        //    for (int i = 0; i < Iterations; i++)
        //    {
        //        unsafe
        //        {
        //            fixed (byte* srcPtr = &ByteArray2[0], destPtr = &DestByteArray1[0])
        //            {
        //                byte* dest = destPtr;
        //                byte* src = srcPtr;
        //                Buffer.MemoryCopy(src, dest, DestByteArray1.Length, ByteArray2.Length);
        //            }
        //        }
        //    }
        //}

        //// int

        //[Benchmark]
        //public void ArrayCopy_Int32_Span()
        //{
        //    for (int i = 0; i < Iterations; i++)
        //    {
        //        Int32Array2.AsSpan().CopyTo(DestInt32Array1.AsSpan());
        //    }
        //}

        //[Benchmark]
        //public void ArrayCopy_Int32_Memory()
        //{
        //    for (int i = 0; i < Iterations; i++)
        //    {
        //        Int32Array2.AsMemory().CopyTo(DestInt32Array1.AsMemory());
        //    }
        //}

        //[Benchmark]
        //public void ArrayCopy_Int32_Array_Copy()
        //{
        //    for (int i = 0; i < Iterations; i++)
        //    {
        //        Array.Copy(Int32Array2, 0, DestInt32Array1, 0, Int32Array2.Length);
        //    }
        //}

        //[Benchmark]
        //public void ArrayCopy_Int32_Buffer_BlockCopy()
        //{
        //    for (int i = 0; i < Iterations; i++)
        //    {
        //        Buffer.BlockCopy(Int32Array2, 0, DestInt32Array1, 0, Int32Array2.Length * sizeof(int));
        //    }
        //}

        ////[Benchmark]
        ////public void ArrayCopy_Int32_Buffer_MemoryCopy()
        ////{
        ////    for (int i = 0; i < Iterations; i++)
        ////    {
        ////        unsafe
        ////        {
        ////            fixed (byte* srcPtr = (byte*)&Int32Array2[0], destPtr = &DestInt32Array1[0])
        ////            {
        ////                byte* dest = destPtr;
        ////                byte* src = srcPtr;
        ////                Buffer.MemoryCopy(src, dest, DestInt32Array1.Length * sizeof(int), Int32Array2.Length * sizeof(int));
        ////            }
        ////        }
        ////    }
        ////}

        //// long

        //[Benchmark]
        //public void ArrayCopy_Int64_Span()
        //{
        //    for (int i = 0; i < Iterations; i++)
        //    {
        //        Int64Array2.AsSpan().CopyTo(DestInt64Array2.AsSpan());
        //    }
        //}

        //[Benchmark]
        //public void ArrayCopy_Int64_Memory()
        //{
        //    for (int i = 0; i < Iterations; i++)
        //    {
        //        Int64Array2.AsMemory().CopyTo(DestInt64Array2.AsMemory());
        //    }
        //}

        //[Benchmark]
        //public void ArrayCopy_Int64_Array_Copy()
        //{
        //    for (int i = 0; i < Iterations; i++)
        //    {
        //        Array.Copy(Int64Array2, 0, DestInt64Array2, 0, Int64Array2.Length);
        //    }
        //}

        //[Benchmark]
        //public void ArrayCopy_Int64_Buffer_BlockCopy()
        //{
        //    for (int i = 0; i < Iterations; i++)
        //    {
        //        Buffer.BlockCopy(Int64Array2, 0, DestInt64Array2, 0, Int64Array2.Length * sizeof(long));
        //    }
        //}

        //[Benchmark]
        //public void ArrayCopy_Int32_Buffer_MemoryCopy()
        //{
        //    for (int i = 0; i < Iterations; i++)
        //    {
        //        unsafe
        //        {
        //            fixed (byte* srcPtr = (byte*)&Int32Array2[0], destPtr = &DestInt32Array1[0])
        //            {
        //                byte* dest = destPtr;
        //                byte* src = srcPtr;
        //                Buffer.MemoryCopy(src, dest, DestInt32Array1.Length * sizeof(int), Int32Array2.Length * sizeof(int));
        //            }
        //        }
        //    }
        //}

        //// char

        //[Benchmark]
        //public void ArrayCopy_Char_Span()
        //{
        //    for (int i = 0; i < Iterations; i++)
        //    {
        //        CharArray2.AsSpan().CopyTo(DestCharArray2.AsSpan());
        //    }
        //}

        //[Benchmark]
        //public void ArrayCopy_Char_Memory()
        //{
        //    for (int i = 0; i < Iterations; i++)
        //    {
        //        CharArray2.AsMemory().CopyTo(DestCharArray2.AsMemory());
        //    }
        //}

        //[Benchmark]
        //public void ArrayCopy_Char_Array_Copy()
        //{
        //    for (int i = 0; i < Iterations; i++)
        //    {
        //        Array.Copy(CharArray2, 0, DestCharArray2, 0, CharArray2.Length);
        //    }
        //}

        //[Benchmark]
        //public void ArrayCopy_Char_Buffer_BlockCopy()
        //{
        //    for (int i = 0; i < Iterations; i++)
        //    {
        //        Buffer.BlockCopy(CharArray2, 0, DestCharArray2, 0, CharArray2.Length * sizeof(char));
        //    }
        //}

        ////[Benchmark]
        ////public void ArrayCopy_Int32_Buffer_MemoryCopy()
        ////{
        ////    for (int i = 0; i < Iterations; i++)
        ////    {
        ////        unsafe
        ////        {
        ////            fixed (byte* srcPtr = (byte*)&Int32Array2[0], destPtr = &DestInt32Array1[0])
        ////            {
        ////                byte* dest = destPtr;
        ////                byte* src = srcPtr;
        ////                Buffer.MemoryCopy(src, dest, DestInt32Array1.Length * sizeof(int), Int32Array2.Length * sizeof(int));
        ////            }
        ////        }
        ////    }
        ////}
        ///


        //// object

        ////[Benchmark]
        ////public void ArrayCopy_Obj_Span()
        ////{
        ////    for (int i = 0; i < Iterations; i++)
        ////    {
        ////        ObjArray2.AsSpan().CopyTo(DestObjArray2.AsSpan());
        ////    }
        ////}

        ////[Benchmark]
        ////public void ArrayCopy_Obj_Memory()
        ////{
        ////    for (int i = 0; i < Iterations; i++)
        ////    {
        ////        ObjArray2.AsMemory().CopyTo(DestObjArray2.AsMemory());
        ////    }
        ////}

        //[Benchmark]
        //public void ArrayCopy_Obj_Array_Copy()
        //{
        //    for (int i = 0; i < Iterations; i++)
        //    {
        //        Array.Copy(ObjArray2, 0, DestObjArray2, 0, ObjArray2.Length);
        //    }
        //}

        ////[Benchmark]
        ////public void ArrayCopy_Obj_Buffer_BlockCopy()
        ////{
        ////    for (int i = 0; i < Iterations; i++)
        ////    {
        ////        Buffer.BlockCopy(CharArray2, 0, DestCharArray2, 0, CharArray2.Length * sizeof(MyClass));
        ////    }
        ////}

        ////[Benchmark]
        ////public void ArrayCopy_Int32_Buffer_MemoryCopy()
        ////{
        ////    for (int i = 0; i < Iterations; i++)
        ////    {
        ////        unsafe
        ////        {
        ////            fixed (byte* srcPtr = (byte*)&Int32Array2[0], destPtr = &DestInt32Array1[0])
        ////            {
        ////                byte* dest = destPtr;
        ////                byte* src = srcPtr;
        ////                Buffer.MemoryCopy(src, dest, DestInt32Array1.Length * sizeof(int), Int32Array2.Length * sizeof(int));
        ////            }
        ////        }
        ////    }
        ////}

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


        // object

        [Benchmark]
        public void ArrayCopy_String_Span()
        {
            for (int i = 0; i < Iterations; i++)
            {
                StringArray2.AsSpan().CopyTo(DestStringArray2.AsSpan());
            }
        }

        [Benchmark]
        public void ArrayCopy_String_Memory()
        {
            for (int i = 0; i < Iterations; i++)
            {
                StringArray2.AsMemory().CopyTo(DestStringArray2.AsMemory());
            }
        }

        [Benchmark]
        public void ArrayCopy_String_Array_Copy()
        {
            for (int i = 0; i < Iterations; i++)
            {
                Array.Copy(StringArray2, 0, DestStringArray2, 0, StringArray2.Length);
            }
        }

        //[Benchmark]
        //public void ArrayCopy_String_Buffer_BlockCopy()
        //{
        //    for (int i = 0; i < Iterations; i++)
        //    {
        //        Buffer.BlockCopy(CharArray2, 0, DestCharArray2, 0, CharArray2.Length * sizeof(MyClass));
        //    }
        //}

        //[Benchmark]
        //public void ArrayCopy_String_Buffer_MemoryCopy()
        //{
        //    for (int i = 0; i < Iterations; i++)
        //    {
        //        unsafe
        //        {
        //            fixed (byte* srcPtr = (byte*)&Int32Array2[0], destPtr = &DestInt32Array1[0])
        //            {
        //                byte* dest = destPtr;
        //                byte* src = srcPtr;
        //                Buffer.MemoryCopy(src, dest, DestInt32Array1.Length * sizeof(int), Int32Array2.Length * sizeof(int));
        //            }
        //        }
        //    }
        //}

        [Benchmark]
        public void ArrayCopy_Obj_ForLoop()
        {
            for (int i = 0; i < Iterations; i++)
            {
                for (int j = 0; j < StringArray2.Length; j++)
                {
                    DestStringArray2[j] = StringArray2[j];
                }
            }
        }


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
