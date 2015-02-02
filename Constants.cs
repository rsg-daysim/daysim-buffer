using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSBuffTool
{
    public class Constants
    {
        public static class DELIMITERS
        {
            public const string IN_DELIMITERS = " -\t-,";
            public const string OUT_DELIMITER = " ";
        }
        
        public static class DISTCALC
        {
            public const string EUCLIDEAN = "Euclidean";
            public const string CIRCUITY = "Circuity";
            public const string NODETONODE = "Node-to-Node";
        }

        public static class BUFFTYPE
        {
            public const string FLAT = "Flat";
            public const string LOGISTIC = "Logistic decay";
            public const string EXPONENTIAL = "Exponential decay";
        }

        public static class BUFFPARAMS
        {
            public const string BUFFDIST1 = "660.0";
            public const string BUFFDECAY1 = "0.76";
            public const string BUFFEXP1 = "-2.5205";
            public const string BUFFOFFSET1 = "2640.0";

            public const string BUFFDIST2 = "1320.0";
            public const string BUFFDECAY2 = "0.76";
            public const string BUFFEXP2 = "-0.4365";
            public const string BUFFOFFSET2 = "2640.0";

            public const double BUFFDLIMIT = 15840.0; //orthogonal distance to be considered for either buffer (for processing speed)
            
            public const int MAXFEET = 52800;
            public const double MAXCIRCVALUE = 5.0;
            public const double DEFAULTCIRCRATIO = 1.41;
            public const double MAXCIRCDIST = 10560.0; //only apply circuity multiplier out to 2 miles = 10560 feet
            public const double DISTLIMIT1 = 2640.0;
            public const double DISTLIMIT2 = 5280.0;
            public const double DISTLIMIT3 = 7920.0;

            public const double TINY = 0.0000000000001;
        }

        public class SIZECONSTS
        {
            public const int MAXNCELS = 2000000; //maximum total number of cells
            public const int NLUSEVARS = 14;
            public const int NPARKTYPES = 2;
            public const int MAXNODES = 400000; // maximum total number of nodes
            public const int MAXNODEID = 9999999;
            public const int MAXINTSECS = 699999;
            public const int MAXSTOPS = 39999;
            public const int MAXPARKS = 1999999;
            public const double MINSQFT = 1.0;

            public const int NDIRECTIONS = 8;
            public const int NDISTBANDS = 3;

            public const int NBUFFERS = 2;
        }

        public static class NDFTYPE
        {
            public const int NO_EXT_AVAIL = 1;
            public const int EXT_AVAIL = 3;
        }

        public static class CUSTOM
        {
            public const bool PSRC = false;
        }

    }
}
