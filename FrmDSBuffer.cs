using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace DSBuffTool
{
    public partial class DSBuff : Form
    {
        // Inputs from userform

        private string InputXMLFileName { get; set; }

        private string DistCalcType { get; set; }

        private string ParcelFileName { get; set; }
        private string IntersectionFileName { get; set; }
        private string TransitStopsFileName { get; set; }
        private string OpenSpacesFileName { get; set; }
        private string CircuityFileName { get; set; }
        private string NodeFileName { get; set; }
        private string NodeDistanceFileName { get; set; }
        
        private string ParcelNodeFileName { get; set; }
        private string IntNodeFileName { get; set; }
        private string StopNodeFileName { get; set; }
        private string OpenNodeFileName { get; set; }
        private string ExtendedNodeFileName { get; set; }
        private string NNIndexFileName { get; set; }
        private string NNIndexBinFileName { get; set; }

        private string BuffTyp { get; set; }
        private double BuffDist1 { get; set; }
        private double BuffDecay1 { get; set; }
        private double BuffExp1 { get; set; }
        private double BuffOffset1 { get; set; }

        private double BuffDist2 { get; set; }
        private double BuffDecay2 { get; set; }
        private double BuffExp2 { get; set; }
        private double BuffOffset2 { get; set; }

        private string ParcelOutputFileName { get; set; }
        private string OutputXMLFileName { get; set; }

        private Logger processLogger;

        private string[] DIRLAB = { "E", "NE", "N", "NW", "W", "SW", "S", "SE" };

        //Buffering process variables
        private int[] nodeind_p = new int[Constants.SIZECONSTS.MAXNCELS + 1];
        private int[] nodeind_i = new int[Constants.SIZECONSTS.MAXINTSECS + 1];
        private int[] nodeind_s = new int[Constants.SIZECONSTS.MAXSTOPS + 1];
        private int[] nodeind_o = new int[Constants.SIZECONSTS.MAXPARKS + 1];
        private double[,] dDecayWeights = new double[Constants.SIZECONSTS.NBUFFERS + 1, Constants.BUFFPARAMS.MAXFEET + 1];


        //Parcel variables
        private long[] parcelid = new long[Constants.SIZECONSTS.MAXNCELS + 1];
        private double[] xcoord_p = new double[Constants.SIZECONSTS.MAXNCELS + 1];
        private double[] ycoord_p = new double[Constants.SIZECONSTS.MAXNCELS + 1];
        private double[] sqft_p = new double[Constants.SIZECONSTS.MAXNCELS + 1];
        private long[] taz_p = new long[Constants.SIZECONSTS.MAXNCELS + 1];
        private long[] type_p = new long[Constants.SIZECONSTS.MAXNCELS + 1];
        private double[,] luse_p = new double[Constants.SIZECONSTS.NLUSEVARS + 1, Constants.SIZECONSTS.MAXNCELS + 1]; //housing, students, employment in single array for easier processing
        private double[,] parksp_p = new double[Constants.SIZECONSTS.NPARKTYPES + 1, Constants.SIZECONSTS.MAXNCELS + 1]; //parking spaces of 2 types in single array
        private double[,] parkpr_p = new double[Constants.SIZECONSTS.NPARKTYPES + 1, Constants.SIZECONSTS.MAXNCELS + 1];
        private int nparcels;

        //Intersection variables
        private long[] links_i;
        private double[] xcoord_i, ycoord_i;
        private int nintsecs;

        //Stop variables
        private long[] mode_s;
        private double[] xcoord_s, ycoord_s;
        private int nstops;

        //Park/Open spaces data variables
        private double[] sqft_o, xcoord_o, ycoord_o;
        private int nparks;

        //Circuity variables
        private double[, ,] circValue;
        private double[] xcoord_c, ycoord_c;
        private int ncircp;

        //Node version only
        private long[] nodeid;
        private double[] xcoord_n;
        private double[] ycoord_n;
        private int nnodes;
        private long[] nodeord;
        private int nodeftype = Constants.NDFTYPE.NO_EXT_AVAIL;
        private double[] totallu_n;
        private double[] sqft_n;
        private double[,] luse_n;
        private double[,] parksp_n;
        private double[,] parkpr_n;
        private double[] nodes1_n, nodes3_n, nodes4_n;

        //More node version variables
        private long currNodeOrd, nextNodeOrd;
        private double[] nnDistance;
        private StreamReader nnReader;
        private string[] nnReaderRow;
        private StreamWriter nindWriter;
        private BinaryWriter nindbinWriter;
        private bool writeNNfiles;
        private long onodeswritten, dnodeswritten, onodefirstrec, onodelastrec;

        //Buffer variables
        private double[, ,] luse_b = new double[Constants.SIZECONSTS.MAXNODES + 1, Constants.SIZECONSTS.NBUFFERS + 1, Constants.SIZECONSTS.NLUSEVARS + 1];
        private double[, ,] parksp_b = new double[Constants.SIZECONSTS.MAXNODES + 1, Constants.SIZECONSTS.NBUFFERS + 1, Constants.SIZECONSTS.NPARKTYPES + 1];
        private double[, ,] parkpr_b = new double[Constants.SIZECONSTS.MAXNODES + 1, Constants.SIZECONSTS.NBUFFERS + 1, Constants.SIZECONSTS.NPARKTYPES + 1];
        private double[,] nodes1 = new double[Constants.SIZECONSTS.MAXNODES + 1, Constants.SIZECONSTS.NBUFFERS + 1];
        private double[,] nodes3 = new double[Constants.SIZECONSTS.MAXNODES + 1, Constants.SIZECONSTS.NBUFFERS + 1];
        private double[,] nodes4 = new double[Constants.SIZECONSTS.MAXNODES + 1, Constants.SIZECONSTS.NBUFFERS + 1];
        private double[,] tstops = new double[Constants.SIZECONSTS.MAXNODES + 1, Constants.SIZECONSTS.NBUFFERS + 1];
        private double[,] bparks = new double[Constants.SIZECONSTS.MAXNODES + 1, Constants.SIZECONSTS.NBUFFERS + 1];
        private double[,] aparks = new double[Constants.SIZECONSTS.MAXNODES + 1, Constants.SIZECONSTS.NBUFFERS + 1];

        private double[,] dist_tran = new double[Constants.SIZECONSTS.MAXNODES + 1, 6];
        private double[] dist_park = new double[Constants.SIZECONSTS.MAXNODES + 1];


        public DSBuff()
        {
            InitializeComponent();
        }

        private void Run_Click(object sender, EventArgs e)
        {
            int direction,distband,sindex;
            int p, n, j, k;
            try
            {
                //Validate input data
                if (!validInputs()) return;

                getBuffParams();
                //Save xml file
                if (txtXMLOutput.Text.Length > 0)
                {
                    OutputXMLFileName = txtXMLOutput.Text;
                    saveXMLFile();
                }
                startLog();

                if (DistCalcType == Constants.DISTCALC.NODETONODE)
                {
                    processLogger.log("Started reading node data");
                    readNodeData();
                    processLogger.log("Finished reading node data");
                }
                processLogger.log("Started reading parcel data");
                readParcelData();
                processLogger.log("Finished reading parcel data");
                processLogger.log("Started reading intersection data");
                readIntsecData();
                processLogger.log("Finished reading intersection data");
                processLogger.log("Started reading transit stops data");
                readStopData();
                processLogger.log("Finished reading transit stops data");
                processLogger.log("Started reading open spaces data");
                readParkData();
                processLogger.log("Finished reading open spaces data");

                if (DistCalcType == Constants.DISTCALC.CIRCUITY)
                {
                    processLogger.log("Started reading circuity data");
                    readCircuityData();
                    processLogger.log("Finished reading circuity data");
                }
                else if (DistCalcType == Constants.DISTCALC.NODETONODE)
                {
                    processLogger.log("Started creating node correspondences");
                    createNearestNodeCorrespondences();
                    processLogger.log("Finished creating node correspondences");
                }

                processLogger.log("Started precalculating distance decay weights");
                precalculateDistanceDecayWeights();
                processLogger.log("Finished precalculating distance decay weights");


                processLogger.log("Started writing out buffered parcel data");
                using (StreamWriter outWriter = new StreamWriter(ParcelOutputFileName,false))
                {
                    string[] header_arr = { "parcelid", "xcoord_p", "ycoord_p", "sqft_p", "taz_p", "lutype_p", "hh_p", "stugrd_p", "stuhgh_p", "stuuni_p", "empedu_p",
                                        "empfoo_p", "empgov_p", "empind_p", "empmed_p", "empofc_p", "empret_p", "empsvc_p", "empoth_p", "emptot_p", "parkdy_p",
                                          "parkhr_p", "ppricdyp", "pprichrp", 
                                          "hh_1", "stugrd_1", "stuhgh_1", "stuuni_1", "empedu_1","empfoo_1", "empgov_1", "empind_1", "empmed_1", "empofc_1", "empret_1",
                                          "empsvc_1", "empoth_1", "emptot_1", "parkdy_1", "parkhr_1", "ppricdy1", "pprichr1",
                                          "nodes1_1", "nodes3_1", "nodes4_1", "tstops_1", "nparks_1", "aparks_1",
                                          "hh_2", "stugrd_2", "stuhgh_2", "stuuni_2", "empedu_2","empfoo_2", "empgov_2", "empind_2", "empmed_2", "empofc_2", "empret_2",
                                          "empsvc_2", "empoth_2", "emptot_2", "parkdy_2", "parkhr_2", "ppricdy2", "pprichr2",
                                          "nodes1_2", "nodes3_2", "nodes4_2", "tstops_2", "nparks_2", "aparks_2",
                                          "dist_lbus", "dist_ebus", "dist_crt", "dist_fry", "dist_lrt", "dist_park"};
                    outWriter.Write(string.Join(Constants.DELIMITERS.OUT_DELIMITER, header_arr));
                    if (DistCalcType == Constants.DISTCALC.CIRCUITY)
                    {
                        for (direction = 1; direction <= Constants.SIZECONSTS.NDIRECTIONS; direction++)
                        {
                            for (distband = 1; distband <= Constants.SIZECONSTS.NDISTBANDS; distband++)
                            {
                                outWriter.Write(Constants.DELIMITERS.OUT_DELIMITER + "Circ_" + DIRLAB[direction] + distband);
                            }
                        }
                    }
                    outWriter.Write("\n");
                }

                if (DistCalcType == Constants.DISTCALC.NODETONODE)
                {
                    //create buffer measures
                    //timestring:=DateTimetoStr(now);
                    //pwriteln(1,'Start buffering around nodes at '+timestring);
                    //writeln('Nodes processed ... ');
                    
                    //first buffer around every node and store
                    openNodeNodeDistanceFile();

                    for (n = 1; n <= nnodes; n++)
                    {
                        //if n mod 1000=0 then write(n:8);
                        getNodeNodeDistances(n);
                        bufferAroundAPoint(xcoord_n[n], ycoord_n[n], n, n);
                    }
                    closeNodeNodeDistanceFile();
                }

                //timestring:=DateTimetoStr(now);
                //pwriteln(1,'Start writing parcel buffer records at '+timestring);
                //writeln('Parcels processed ... ');

                //loop on parcels from parcel file
                for (p = 1; p <= nparcels; p++)
                {
                    if (p % 1000 == 0) Console.WriteLine("Wrote {0} records", p);
                    if (taz_p[p] > 0) //don't bother buffering if invalid zone number
                    {
                        //if using nodes, just take buffer record from nearest node, else buffer and take from sindex=1
                        if (DistCalcType == Constants.DISTCALC.NODETONODE)
                        {
                            sindex = nodeind_p[p];
                        }
                        else
                        {
                            sindex = 1;
                            bufferAroundAPoint(xcoord_p[p], ycoord_p[p], p, sindex);
                        }

                        //write record for parcel
                        using (StreamWriter outWriter = new StreamWriter(ParcelOutputFileName,true))
                        {
                            //first copy existing parcel variables
                            List<string> outstr_list = new List<string>();
                            outstr_list.Add(parcelid[p].ToString());
                            outstr_list.Add(xcoord_p[p].ToString("F0"));
                            outstr_list.Add(ycoord_p[p].ToString("F0"));
                            outstr_list.Add(sqft_p[p].ToString("F0"));
                            outstr_list.Add(taz_p[p].ToString());
                            outstr_list.Add(type_p[p].ToString());
                            for (k = 1; k <= Constants.SIZECONSTS.NLUSEVARS; k++) outstr_list.Add(luse_p[k, p].ToString("F2"));
                            for (k = 1; k <= Constants.SIZECONSTS.NPARKTYPES; k++) outstr_list.Add(parksp_p[k, p].ToString("F2"));
                            for (k = 1; k <= Constants.SIZECONSTS.NPARKTYPES; k++) outstr_list.Add(parkpr_p[k, p].ToString("F2"));

                            //then add buffer variables
                            for (j = 1; j <= Constants.SIZECONSTS.NBUFFERS; j++)
                            {
                                for (k = 1; k <= Constants.SIZECONSTS.NLUSEVARS; k++) outstr_list.Add(luse_b[sindex, j, k].ToString("F2"));
                                for (k = 1; k <= Constants.SIZECONSTS.NPARKTYPES; k++) outstr_list.Add(parksp_b[sindex, j, k].ToString("F2"));
                                for (k = 1; k <= Constants.SIZECONSTS.NPARKTYPES; k++) outstr_list.Add((parkpr_b[sindex, j, k] / (parksp_b[sindex, j, k] + 0.000000001)).ToString("F2")); //use average price
                                outstr_list.Add(nodes1[sindex, j].ToString("F2"));
                                outstr_list.Add(nodes3[sindex, j].ToString("F2"));
                                outstr_list.Add(nodes4[sindex, j].ToString("F2"));
                                outstr_list.Add(tstops[sindex, j].ToString("F2"));
                                outstr_list.Add(bparks[sindex, j].ToString("F2"));
                                outstr_list.Add((aparks[sindex, j] / (bparks[sindex, j] + 0.000001)).ToString("F0"));
                            }
                            
                            //write distance variables
                            for (k = 1; k <= 5; k++) outstr_list.Add(dist_tran[sindex, k].ToString("F2"));
                            outstr_list.Add(dist_park[sindex].ToString("F2"));

                            if (DistCalcType == Constants.DISTCALC.CIRCUITY)
                            {
                                for (direction = 1; direction <= Constants.SIZECONSTS.NDIRECTIONS; direction++)
                                {
                                    for (distband = 1; distband <= Constants.SIZECONSTS.NDISTBANDS; distband++)
                                    {
                                        outstr_list.Add(circValue[p, direction, distband].ToString("F2"));
                                    }
                                }
                            }

                            outWriter.WriteLine(string.Join(Constants.DELIMITERS.OUT_DELIMITER, outstr_list.ToArray()));
                        }
                    }
                }

                processLogger.log("Finished writing out buffered parcel data");
                processLogger.log("Finished buffering process");
                MessageBox.Show("Run finished successfully!");
                return;
            }

            catch(System.Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
                MessageBox.Show("Unsuccessful run!");
                return;
            }

        }

        private bool validInputs()
        {
            string[] errors;
            List<string> errstr_list = new List<string>();

            if (txtParcelData.Text.Length == 0) errstr_list.Add("Please select: " + lblParcelData.Text);
            if (txtIntersection.Text.Length == 0) errstr_list.Add("Please select: " + lblIntersection.Text);
            if (txtTransitStops.Text.Length == 0) errstr_list.Add("Please select: " + lblTransitStops.Text);
            //if (txtOpenSpaces.Text.Length == 0) errstr_list.Add("Please select: " + lblOpenSpaces.Text); //not mandatory

            if (txtCircuity.Text.Length == 0 & rdbCircuity.Checked) errstr_list.Add("Please select: " + lblCircuity.Text);
            if (txtNodeData.Text.Length == 0 & rdbNode.Checked) errstr_list.Add("Please select: " + lblNodeData.Text);
            if (txtNodeDistance.Text.Length == 0 & rdbNode.Checked) errstr_list.Add("Please select: " + lblNodeDistance.Text);
            if (txtExtNode.Text.Length == 0 & rdbNode.Checked) errstr_list.Add("Please select: " + lblExtNode.Text);
            if (txtParcelNode.Text.Length == 0 & rdbNode.Checked) errstr_list.Add("Please select: " + lblParcelNode.Text);
            if (txtIntNode.Text.Length == 0 & rdbNode.Checked) errstr_list.Add("Please select: " + lblIntNode.Text);
            if (txtStopNode.Text.Length == 0 & rdbNode.Checked) errstr_list.Add("Please select: " + lblStopNode.Text);
            if (txtOpenSpaces.Text.Length>0 & txtOpenSpacesNode.Text.Length == 0 & rdbNode.Checked) errstr_list.Add("Please select: " + lblOpenSpacesNode.Text);


            if (txtOutputParcel.Text.Length == 0) errstr_list.Add("Please select: " + lblOutputParcel.Text);

            double testnum;
            if (!Double.TryParse(txtBuffDist1.Text, out testnum)) errstr_list.Add("Please enter a valid number: " + lblBuffDist1.Text);
            if (rdbBuffTypLog.Checked & !Double.TryParse(txtBuffDecay1.Text, out testnum)) errstr_list.Add("Please enter a valid number: " + lblBuffDecay1.Text);
            if (rdbBuffTypLog.Checked & !Double.TryParse(txtBuffOffset1.Text, out testnum)) errstr_list.Add("Please enter a valid number: " + lblBuffOffset1.Text);
            if (rdbBuffTypExp.Checked & !Double.TryParse(txtBuffExp1.Text, out testnum)) errstr_list.Add("Please enter a valid number: " + lblBuffExp1.Text);
            
            if (!Double.TryParse(txtBuffDist2.Text, out testnum)) errstr_list.Add("Please enter a valid number: " + lblBuffDist2.Text);
            if (rdbBuffTypLog.Checked & !Double.TryParse(txtBuffDecay2.Text, out testnum)) errstr_list.Add("Please enter a valid number: " + lblBuffDecay2.Text);
            if (rdbBuffTypLog.Checked & !Double.TryParse(txtBuffOffset2.Text, out testnum)) errstr_list.Add("Please enter a valid number: " + lblBuffOffset2.Text);
            if (rdbBuffTypExp.Checked & !Double.TryParse(txtBuffExp2.Text, out testnum)) errstr_list.Add("Please enter a valid number: " + lblBuffExp2.Text);
            
            if (errstr_list.Any())
            {
                errors = errstr_list.ToArray();
                MessageBox.Show(string.Join("\n", errors),"Missing Items");
                return false;
            }
            else return true;
        }


        private void saveXMLFile()
        {
            XmlWriterSettings xSettings = new XmlWriterSettings();
            xSettings.Indent = true;
            xSettings.NewLineOnAttributes = true;
            using (XmlWriter xWriter = XmlWriter.Create(OutputXMLFileName, xSettings))
            {
                xWriter.WriteStartDocument();
                xWriter.WriteStartElement("DaySimBufferingTool"); // <DaySimBufferingTool>

                xWriter.WriteStartElement("INPUTS"); // <INPUTS>

                xWriter.WriteStartElement("FILEPATHS"); // <FILEPATHS>
                xWriter.WriteElementString("ParcelFile", ParcelFileName); // <ParcelFile>
                xWriter.WriteElementString("IntersectionFile", IntersectionFileName); // <IntersectionFile>
                xWriter.WriteElementString("TransitStopsFile", TransitStopsFileName); // <TransitStopsFile>
                xWriter.WriteElementString("OpenSpacesFile", OpenSpacesFileName); // <OpenSpacesFile>
                xWriter.WriteElementString("CircuityFile", CircuityFileName); // <CircuityFile>
                xWriter.WriteElementString("NodeFile", NodeFileName); // <NodeFile>
                xWriter.WriteElementString("NodeDistanceFile", NodeDistanceFileName); // <NodeDistanceFile>
                xWriter.WriteElementString("ExtendedNodeFile", ExtendedNodeFileName); // <ExtendedNodeFile>
                xWriter.WriteElementString("ParcelNodeFile", ParcelNodeFileName); // <ParcelNodeFile>
                xWriter.WriteElementString("IntNodeFile", IntNodeFileName); // <IntNodeFile>
                xWriter.WriteElementString("StopNodeFile", StopNodeFileName); // <StopNodeFile>
                xWriter.WriteElementString("OpenSpacesNodeFile", OpenNodeFileName); // <OpenSpacesNodeFile>
                xWriter.WriteEndElement(); // </FILEPATHS>

                xWriter.WriteStartElement("PARAMETERS"); // <PARAMETERS>
                xWriter.WriteElementString("DistCalcType", Convert.ToString(DistCalcType)); // <DistCalcType>
                xWriter.WriteElementString("BuffType", Convert.ToString(BuffTyp)); // <BuffType>
                xWriter.WriteElementString("BuffDist1", Convert.ToString(BuffDist1)); // <BuffDist1>
                xWriter.WriteElementString("BuffDecaySlope1", Convert.ToString(BuffDecay1)); // <BuffDecaySlope1>
                xWriter.WriteElementString("BuffExpParam1", Convert.ToString(BuffExp1)); // <BuffEpxParam1>
                xWriter.WriteElementString("BuffOffset1", Convert.ToString(BuffOffset1)); // <BuffOffset1>
                xWriter.WriteElementString("BuffDist2", Convert.ToString(BuffDist2)); // <BuffDist2>
                xWriter.WriteElementString("BuffDecaySlope2", Convert.ToString(BuffDecay2)); // <BuffDecaySlope2>
                xWriter.WriteElementString("BuffExpParam2", Convert.ToString(BuffExp2)); // <BuffEpxParam2>
                xWriter.WriteElementString("BuffOffset2", Convert.ToString(BuffOffset2)); // <BuffOffset2>
                xWriter.WriteEndElement(); // </PARAMETERS>

                xWriter.WriteEndElement(); // </INPUTS>

                xWriter.WriteStartElement("OUTPUTS"); // <OUTPUTS>
                xWriter.WriteElementString("BufferedParcelFile", ParcelOutputFileName); // <BufferedParcelFile>
                xWriter.WriteElementString("SaveXMLFile", OutputXMLFileName); // <SaveXMLFile>
                xWriter.WriteEndElement(); // </OUTPUTS>

                xWriter.WriteEndElement(); // </DaySimBufferingTool>
                xWriter.WriteEndDocument();
            }
        }

        private void readXmlFile(string xmlInputFile)
        {
            using (XmlReader xReader = XmlReader.Create(xmlInputFile))
            {
                while (xReader.Read())
                {
                    switch(xReader.Name)
                    {
                        case "DistCalcType":
                            string dt = xReader.ReadElementContentAsString();
                            if (dt == Constants.DISTCALC.EUCLIDEAN) rdbEuclidean.Checked = true;
                            else if (dt == Constants.DISTCALC.CIRCUITY) rdbCircuity.Checked = true;
                            else if (dt == Constants.DISTCALC.NODETONODE) rdbNode.Checked = true;
                            break;
                        case "ParcelFile":
                            txtParcelData.Text = xReader.ReadElementContentAsString();
                            break;
                        case "IntersectionFile":
                            txtIntersection.Text = xReader.ReadElementContentAsString();
                            break;
                        case "TransitStopsFile":
                            txtTransitStops.Text = xReader.ReadElementContentAsString();
                            break;
                        case "OpenSpacesFile":
                            txtOpenSpaces.Text = xReader.ReadElementContentAsString();
                            break;
                        case "CircuityFile":
                            txtCircuity.Text = xReader.ReadElementContentAsString();
                            break;
                        case "NodeFile":
                            txtNodeData.Text = xReader.ReadElementContentAsString();
                            break;
                        case "NodeDistanceFile":
                            txtNodeDistance.Text = xReader.ReadElementContentAsString();
                            break;
                        case "ExtendedNodeFile":
                            txtExtNode.Text = xReader.ReadElementContentAsString();
                            break;
                        case "ParcelNodeFile":
                            txtParcelNode.Text = xReader.ReadElementContentAsString();
                            break;
                        case "IntNodeFile":
                            txtIntNode.Text = xReader.ReadElementContentAsString();
                            break;
                        case "StopNodeFile":
                            txtStopNode.Text = xReader.ReadElementContentAsString();
                            break;
                        case "OpenSpacesNodeFile":
                            txtOpenSpacesNode.Text = xReader.ReadElementContentAsString();
                            break;

                        case "BuffType":
                            string bt = xReader.ReadElementContentAsString();
                            if (bt == Constants.BUFFTYPE.FLAT) rdbBuffTypFlat.Checked = true;
                            else if (bt == Constants.BUFFTYPE.LOGISTIC) rdbBuffTypLog.Checked = true;
                            else if (bt == Constants.BUFFTYPE.EXPONENTIAL) rdbBuffTypExp.Checked = true;
                            break;
                        case "BuffDist1":
                            txtBuffDist1.Text = xReader.ReadElementContentAsString();
                            break;
                        case "BuffDecaySlope1":
                            txtBuffDecay1.Text = xReader.ReadElementContentAsString();
                            break;
                        case "BuffExpParam1":
                            txtBuffExp1.Text = xReader.ReadElementContentAsString();
                            break;
                        case "BuffOffset1":
                            txtBuffOffset1.Text = xReader.ReadElementContentAsString();
                            break;
                        case "BuffDist2":
                            txtBuffDist2.Text = xReader.ReadElementContentAsString();
                            break;
                        case "BuffDecaySlope2":
                            txtBuffDecay2.Text = xReader.ReadElementContentAsString();
                            break;
                        case "BuffExpParam2":
                            txtBuffExp2.Text = xReader.ReadElementContentAsString();
                            break;
                        case "BuffOffset2":
                            txtBuffOffset2.Text = xReader.ReadElementContentAsString();
                            break;

                        case "BufferedParcelFile":
                            txtOutputParcel.Text = xReader.ReadElementContentAsString();
                            break;
                        case "SaveXMLFile":
                            txtXMLOutput.Text = xReader.ReadElementContentAsString();
                            break;
                    }
                }
            }
        }

        private void readNodeData()
        {
            nodeid = new long[Constants.SIZECONSTS.MAXNODES + 1];
            xcoord_n = new double[Constants.SIZECONSTS.MAXNODES + 1];
            ycoord_n = new double[Constants.SIZECONSTS.MAXNODES + 1];
            nodeord = new long[Constants.SIZECONSTS.MAXNODEID + 1];
            totallu_n = new double[Constants.SIZECONSTS.MAXNODES + 1];
            sqft_n = new double[Constants.SIZECONSTS.MAXNODES + 1];
            luse_n = new double[Constants.SIZECONSTS.NLUSEVARS + 1, Constants.SIZECONSTS.MAXNODES + 1];
            parksp_n = new double[Constants.SIZECONSTS.NPARKTYPES + 1, Constants.SIZECONSTS.MAXNODES + 1];
            parkpr_n = new double[Constants.SIZECONSTS.NPARKTYPES + 1, Constants.SIZECONSTS.MAXNODES + 1];
            nodes1_n = new double[Constants.SIZECONSTS.MAXNODES + 1];
            nodes3_n = new double[Constants.SIZECONSTS.MAXNODES + 1];
            nodes4_n = new double[Constants.SIZECONSTS.MAXNODES + 1];

            int i, j, k;
            string nodeline;
            string[] row;

            if (File.Exists(ExtendedNodeFileName))
            {
                nodeftype = Constants.NDFTYPE.EXT_AVAIL;
                processLogger.log("Started reading extended node file");
                try
                {
                    using (StreamReader extnodeReader = new StreamReader(ExtendedNodeFileName))
                    {
                        extnodeReader.ReadLine(); //header
                        i = 0;
                        while ((nodeline = extnodeReader.ReadLine()) != null)
                        {
                            i += 1;
                            if (i % 10000 == 0) Console.WriteLine("Read {0} records", i);
                            row = nodeline.Split(Constants.DELIMITERS.IN_DELIMITERS.Split(new[] { '-' }), StringSplitOptions.RemoveEmptyEntries);
                            nodeid[i] = Convert.ToInt64(row[0]);
                            xcoord_n[i] = Convert.ToDouble(row[1]);
                            ycoord_n[i] = Convert.ToDouble(row[2]);
                            sqft_n[i] = Convert.ToDouble(row[3]);
                            totallu_n[i] = Convert.ToDouble(row[4]);
                            for (k = 1, j = 5; k <= Constants.SIZECONSTS.NLUSEVARS; k++, j++) luse_n[k, i] = Convert.ToDouble(row[j]);
                            for (k = 1; k <= Constants.SIZECONSTS.NPARKTYPES; k++, j++) parksp_n[k, i] = Convert.ToDouble(row[j]);
                            for (k = 1; k <= Constants.SIZECONSTS.NPARKTYPES; k++, j++) parkpr_n[k, i] = Convert.ToDouble(row[j]);

                            nodes1_n[i] = Convert.ToDouble(row[j]); j++;
                            nodes3_n[i] = Convert.ToDouble(row[j]); j++;
                            nodes4_n[i] = Convert.ToDouble(row[j]);

                        }
                        nnodes = i;
                        Console.WriteLine("Read {0} records", i);
                    }
                    //set ordinal id indexing
                    for (i = 1; i <= Constants.SIZECONSTS.MAXNODEID; i++) nodeord[i] = 0;
                    for (i = 1; i <= nnodes; i++) nodeord[nodeid[i]] = i;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error reading extended node file\n" + e.Message);
                    processLogger.log(e.Message, "ERROR");
                    throw e;
                }
                processLogger.log("Finished reading extended node file");
            }
            else
            {
                nodeftype = Constants.NDFTYPE.NO_EXT_AVAIL;
                try
                {
                    using (StreamReader nodeReader = new StreamReader(NodeFileName))
                    {
                        nodeReader.ReadLine(); //header
                        i = 0;
                        while ((nodeline = nodeReader.ReadLine()) != null)
                        {
                            i += 1;
                            if (i % 10000 == 0) Console.WriteLine("Read {0} records", i);
                            row = nodeline.Split(Constants.DELIMITERS.IN_DELIMITERS.Split(new[] { '-' }), StringSplitOptions.RemoveEmptyEntries);
                            nodeid[i] = Convert.ToInt64(row[0]);
                            xcoord_n[i] = Convert.ToDouble(row[1]);
                            ycoord_n[i] = Convert.ToDouble(row[2]);
                        }
                        nnodes = i;
                        Console.WriteLine("Read {0} records", i);
                    }
                    //set ordinal id indexing
                    for (i = 1; i <= Constants.SIZECONSTS.MAXNODEID; i++) nodeord[i] = 0;
                    for (i = 1; i <= nnodes; i++) nodeord[nodeid[i]] = i;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error reading node file\n" + e.Message);
                    processLogger.log(e.Message, "ERROR");
                    throw e;
                }
            }

        }

        private void readParcelData()
        {
            int i, j, k;
            string parcelline;
            string[] row;

            try
            {
                using (StreamReader parcelReader = new StreamReader(ParcelFileName))
                {
                    parcelReader.ReadLine(); //header
                    i = 0;
                    while ((parcelline = parcelReader.ReadLine()) != null)
                    {
                        i += 1;
                        if (i % 10000 == 0) Console.WriteLine("Read {0} records", i);
                        row = parcelline.Split(Constants.DELIMITERS.IN_DELIMITERS.Split(new[] { '-' }), StringSplitOptions.RemoveEmptyEntries);
                        parcelid[i] = Convert.ToInt64(row[0]);
                        xcoord_p[i] = Convert.ToDouble(row[1]);
                        ycoord_p[i] = Convert.ToDouble(row[2]);
                        sqft_p[i] = Convert.ToDouble(row[3]);
                        taz_p[i] = Convert.ToInt64(row[4]);
                        type_p[i] = Convert.ToInt64(Convert.ToDouble(row[5]));
                        for (k = 1, j = 6; k <= Constants.SIZECONSTS.NLUSEVARS; k++, j++) luse_p[k, i] = Convert.ToDouble(row[j]);
                        for (k = 1; k <= Constants.SIZECONSTS.NPARKTYPES; k++, j++) parksp_p[k, i] = Convert.ToDouble(row[j]);
                        for (k = 1; k <= Constants.SIZECONSTS.NPARKTYPES; k++, j++) parkpr_p[k, i] = Convert.ToDouble(row[j]);
                        //adjustments - min parcel size
                        if (sqft_p[i] < Constants.SIZECONSTS.MINSQFT) sqft_p[i] = Constants.SIZECONSTS.MINSQFT;
                    }
                    nparcels = i;
                    Console.WriteLine("Read {0} records", i);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error reading Parcel file\n" + e.Message);
                processLogger.log(e.Message, "ERROR");
                throw e;
            }
        }

        private void readIntsecData()
        {
            links_i = new long[Constants.SIZECONSTS.MAXINTSECS + 1];
            xcoord_i = new double[Constants.SIZECONSTS.MAXINTSECS + 1];
            ycoord_i = new double[Constants.SIZECONSTS.MAXINTSECS + 1];

            int i;
            string line;
            string[] row;
            try
            {
                if (IntersectionFileName != "")
                {
                    using (StreamReader intersectionReader = new StreamReader(IntersectionFileName))
                    {
                        intersectionReader.ReadLine(); //header
                        i = 0;
                        while ((line = intersectionReader.ReadLine()) != null)
                        {
                            i += 1;
                            if (i % 10000 == 0) Console.WriteLine("Read {0} records", i);
                            row = line.Split(Constants.DELIMITERS.IN_DELIMITERS.Split(new[] { '-' }), StringSplitOptions.RemoveEmptyEntries);
                            links_i[i] = Convert.ToInt64(row[1]);
                            xcoord_i[i] = Convert.ToDouble(row[2]);
                            ycoord_i[i] = Convert.ToDouble(row[3]);
                        }
                        nintsecs = i;
                        Console.WriteLine("Read {0} records", i);
                    }
                }
                else nintsecs = 0;
                
            }
            catch (Exception e)
            {
                MessageBox.Show("Error reading Intersection file\n" + e.Message);
                processLogger.log(e.Message, "ERROR");
                throw e;
            }
        }

        private void readStopData()
        {
            mode_s = new long[Constants.SIZECONSTS.MAXSTOPS + 1];
            xcoord_s = new double[Constants.SIZECONSTS.MAXSTOPS + 1];
            ycoord_s = new double[Constants.SIZECONSTS.MAXSTOPS + 1];
            
            int i;
            string line;
            string[] row;
            try
            {
                if (TransitStopsFileName != "")
                {
                    using (StreamReader stopReader = new StreamReader(TransitStopsFileName))
                    {
                        stopReader.ReadLine(); //header
                        i = 0;
                        while ((line = stopReader.ReadLine()) != null)
                        {
                            i += 1;
                            if (i % 10000 == 0) Console.WriteLine("Read {0} records", i);
                            row = line.Split(Constants.DELIMITERS.IN_DELIMITERS.Split(new[] { '-' }), StringSplitOptions.RemoveEmptyEntries);
                            mode_s[i] = Convert.ToInt64(row[1]);
                            xcoord_s[i] = Convert.ToDouble(row[2]);
                            ycoord_s[i] = Convert.ToDouble(row[3]);
                        }
                        nstops = i;
                        Console.WriteLine("Read {0} records", i);
                    }
                }
                else nstops = 0;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error reading Trasit Stops file\n" + e.Message);
                processLogger.log(e.Message, "ERROR");
                throw e;
            }
        }

        private void readParkData()
        {
            int i;
            string line;
            string[] row;
            try
            {
                if (OpenSpacesFileName != "")
                {
                    sqft_o = new double[Constants.SIZECONSTS.MAXPARKS + 1];
                    xcoord_o = new double[Constants.SIZECONSTS.MAXPARKS + 1];
                    ycoord_o = new double[Constants.SIZECONSTS.MAXPARKS + 1];
                    using (StreamReader parkReader = new StreamReader(OpenSpacesFileName))
                    {
                        parkReader.ReadLine(); //header
                        i = 0;
                        while ((line = parkReader.ReadLine()) != null)
                        {
                            i += 1;
                            if (i % 10000 == 0) Console.WriteLine("Read {0} records", i); ;
                            row = line.Split(Constants.DELIMITERS.IN_DELIMITERS.Split(new[] { '-' }), StringSplitOptions.RemoveEmptyEntries);
                            xcoord_o[i] = Convert.ToDouble(row[1]);
                            ycoord_o[i] = Convert.ToDouble(row[2]);
                            sqft_o[i] = Convert.ToDouble(row[3]);
                        }
                        nparks = i;
                        Console.WriteLine("Read {0} records", i);
                    }
                }
                else nparks = 0;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error reading Open Spaces file\n" + e.Message);
                processLogger.log(e.Message, "ERROR");
                throw e;
            }
        }

        private void readCircuityData()
        {
            circValue = new double[Constants.SIZECONSTS.MAXNCELS + 1, Constants.SIZECONSTS.NDIRECTIONS + 1, Constants.SIZECONSTS.NDISTBANDS + 1];
            xcoord_c = new double[Constants.SIZECONSTS.MAXNCELS + 1];
            ycoord_c = new double[Constants.SIZECONSTS.MAXNCELS + 1];

            int i, j, direction, distband;
            long parcelid2;
            string line;
            string[] row;
            try
            {
                if (CircuityFileName != "")
                {
                    using (StreamReader circReader = new StreamReader(CircuityFileName))
                    {
                        circReader.ReadLine(); //header
                        i = 0; j = 0;
                        while ((line = circReader.ReadLine()) != null)
                        {
                            i += 1;
                            if (i % 10000 == 0) Console.WriteLine("Read {0} records", i);
                            row = line.Split(Constants.DELIMITERS.IN_DELIMITERS.Split(new[] { '-' }), StringSplitOptions.RemoveEmptyEntries);
                            parcelid2 = Convert.ToInt64(row[j]);
                            if (parcelid2 != parcelid[i])
                            {
                                throw new InvalidOperationException("parcel " + i + " on circuity file has wrong id " + parcelid2 + " should be " + parcelid[i]);
                            }

                            for (direction = 1; direction <= Constants.SIZECONSTS.NDIRECTIONS; direction++)
                            {
                                for (distband = 1; distband <= Constants.SIZECONSTS.NDISTBANDS; distband++)
                                {
                                    j++;
                                    circValue[i, direction, distband] = Convert.ToDouble(row[j]);
                                    if (circValue[i, direction, distband] > Constants.BUFFPARAMS.MAXCIRCVALUE) circValue[i, direction, distband] = Constants.BUFFPARAMS.MAXCIRCVALUE;
                                }
                            }
                        }
                        ncircp = i;
                        Console.WriteLine("Read {0} records", i);
                    }
                }
                else ncircp = 0;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error reading Open Spaces file\n" + e.Message);
                processLogger.log(e.Message, "ERROR");
                throw e;
            }
        }

        private int nearestNode(double x, double y)
        {
            double ndist = 999999999999;
            int nindex = 0;
            double idist;
            for (int i = 1; i <= nnodes; i++)
            {
                idist = Math.Sqrt((x - xcoord_n[i]) * (x - xcoord_n[i]) + (y - ycoord_n[i]) * (y - ycoord_n[i]));
                if (idist < ndist)
                {
                    ndist = idist;
                    nindex = i;
                }
            }
            return nindex;
        }

        private void createNearestNodeCorrespondences()
        {
            int i,n,p,k;
            string line;
            string[] row;

            if (File.Exists(ParcelNodeFileName))
            {
                processLogger.log("Started reading parcel-node correspondence");
                using (StreamReader parcelnodeReader = new StreamReader(ParcelNodeFileName))
                {
                    parcelnodeReader.ReadLine(); //header
                    for (i = 1; i <= nparcels; i++)
                    {
                        if (i % 10000 == 0) Console.WriteLine("Read {0} records", i);
                        line = parcelnodeReader.ReadLine();
                        row = line.Split(Constants.DELIMITERS.IN_DELIMITERS.Split(new[] { '-' }), StringSplitOptions.RemoveEmptyEntries);
                        nodeind_p[i] = Convert.ToInt32(row[1]);
                    }
                }
                processLogger.log("Finished reading parcel-node correspondence");
            }
            else
            {
                processLogger.log("Started creating parcel-node correspondence");
                for (i = 1; i <= nparcels; i++)
                {
                    if (i % 5000 == 0) Console.WriteLine("{0}", i);
                    nodeind_p[i] = nearestNode(xcoord_p[i],ycoord_p[i]);
                }
                using (StreamWriter parcelnodeWriter = new StreamWriter(ParcelNodeFileName))
                {
                    parcelnodeWriter.WriteLine("id"+Constants.DELIMITERS.OUT_DELIMITER+"node_id");
                    for (i = 1; i <= nparcels; i++)
                    {
                        parcelnodeWriter.WriteLine(parcelid[i] + Constants.DELIMITERS.OUT_DELIMITER + nodeind_p[i]);
                    }
                }
                processLogger.log("Finished creating parcel-node correspondence");
            }

            if (File.Exists(IntNodeFileName))
            {
                processLogger.log("Started reading intersection-node correspondence");
                using (StreamReader intsecnodeReader = new StreamReader(IntNodeFileName))
                {
                    intsecnodeReader.ReadLine(); //header
                    for (i = 1; i <= nintsecs; i++)
                    {
                        if (i % 10000 == 0) Console.WriteLine("Read {0} records", i);
                        line = intsecnodeReader.ReadLine();
                        row = line.Split(Constants.DELIMITERS.IN_DELIMITERS.Split(new[] { '-' }), StringSplitOptions.RemoveEmptyEntries);
                        nodeind_i[i] = Convert.ToInt32(row[1]);
                    }
                }
                processLogger.log("Finished reading intersection-node correspondence");
            }
            else
            {
                processLogger.log("Started creating intersection-node correspondence");
                for (i = 1; i <= nintsecs; i++)
                {
                    if (i % 5000 == 0) Console.WriteLine("{0}", i);
                    nodeind_i[i] = nearestNode(xcoord_i[i], ycoord_i[i]);
                }
                using (StreamWriter intsecnodeWriter = new StreamWriter(IntNodeFileName))
                {
                    intsecnodeWriter.WriteLine("id" + Constants.DELIMITERS.OUT_DELIMITER + "node_id");
                    for (i = 1; i <= nintsecs; i++)
                    {
                        intsecnodeWriter.WriteLine(i + Constants.DELIMITERS.OUT_DELIMITER + nodeind_i[i]);
                    }
                }
                processLogger.log("Finished creating intersection-node correspondence");
            }

            if (File.Exists(StopNodeFileName))
            {
                processLogger.log("Started reading stop-node correspondence");
                using (StreamReader stopnodeReader = new StreamReader(StopNodeFileName))
                {
                    stopnodeReader.ReadLine(); //header
                    for (i = 1; i <= nstops; i++)
                    {
                        if (i % 10000 == 0) Console.WriteLine("Read {0} records", i);
                        line = stopnodeReader.ReadLine();
                        row = line.Split(Constants.DELIMITERS.IN_DELIMITERS.Split(new[] { '-' }), StringSplitOptions.RemoveEmptyEntries);
                        nodeind_s[i] = Convert.ToInt32(row[1]);
                    }
                }
                processLogger.log("Finished reading stop-node correspondence");
            }
            else
            {
                processLogger.log("Started creating stop-node correspondence");
                for (i = 1; i <= nstops; i++)
                {
                    if (i % 5000 == 0) Console.WriteLine("{0}", i);
                    nodeind_s[i] = nearestNode(xcoord_s[i], ycoord_s[i]);
                }
                using (StreamWriter stopnodeWriter = new StreamWriter(StopNodeFileName))
                {
                    stopnodeWriter.WriteLine("id" + Constants.DELIMITERS.OUT_DELIMITER + "node_id");
                    for (i = 1; i <= nstops; i++)
                    {
                        stopnodeWriter.WriteLine(i + Constants.DELIMITERS.OUT_DELIMITER + nodeind_s[i]);
                    }
                }
                processLogger.log("Finished creating stop-node correspondence");
            }

            if (File.Exists(OpenNodeFileName))
            {
                using (StreamReader opennodeReader = new StreamReader(OpenNodeFileName))
                {
                    processLogger.log("Started reading openspaces-node correspondence");
                    opennodeReader.ReadLine(); //header
                    for (i = 1; i <= nparks; i++)
                    {
                        if (i % 10000 == 0) Console.WriteLine("Read {0} records", i);
                        line = opennodeReader.ReadLine();
                        row = line.Split(Constants.DELIMITERS.IN_DELIMITERS.Split(new[] { '-' }), StringSplitOptions.RemoveEmptyEntries);
                        nodeind_o[i] = Convert.ToInt32(row[1]);
                    }
                    processLogger.log("Finished reading openspaces-node correspondence");
                }
            }
            else
            {
                if (OpenSpacesFileName != "")
                {
                    processLogger.log("Started creating openspaces-node correspondence");
                    for (i = 1; i <= nparks; i++)
                    {
                        if (i % 5000 == 0) Console.WriteLine("{0}", i);
                        nodeind_o[i] = nearestNode(xcoord_o[i], ycoord_o[i]);
                    }
                    using (StreamWriter opennodeWriter = new StreamWriter(OpenNodeFileName))
                    {
                        opennodeWriter.WriteLine("id" + Constants.DELIMITERS.OUT_DELIMITER + "node_id");
                        for (i = 1; i <= nparks; i++)
                        {
                            opennodeWriter.WriteLine(i + Constants.DELIMITERS.OUT_DELIMITER + nodeind_o[i]);
                        }
                    }
                    processLogger.log("Finished creating openspaces-node correspondence");
                }  
            }

            if (nodeftype == Constants.NDFTYPE.NO_EXT_AVAIL)
            {
                //collapse parcel land use to nodes
                Console.WriteLine("Appending parcel and intersection land use to nodes");
                //empty the variables
                for (n = 1; n <= nnodes; n++)
                {
                    sqft_n[n] = 0;
                    totallu_n[n] = 0;
                    for (k = 1; k <= Constants.SIZECONSTS.NLUSEVARS; k++) luse_n[k, n] = 0;
                    for (k = 1; k <= Constants.SIZECONSTS.NPARKTYPES; k++) parksp_n[k, n] = 0;
                    for (k = 1; k <= Constants.SIZECONSTS.NPARKTYPES; k++) parkpr_n[k, n] = 0;
                    nodes1_n[n] = 0;
                    nodes3_n[n] = 0;
                    nodes4_n[n] = 0;
                }

                for (p = 1; p <= nparcels; p++)
                {
                    if (p % 10000 == 0) Console.WriteLine("Processed {0} parcel records", p);
                    n = nodeind_p[p];
                    if (n > 0)
                    {
                        sqft_n[n] = sqft_n[n] + sqft_p[p];
                        for (k = 1; k <= Constants.SIZECONSTS.NLUSEVARS; k++)
                        {
                            luse_n[k, n] = luse_n[k, n] + luse_p[k, p];
                            totallu_n[n] = totallu_n[n] + luse_p[k, p];
                        }
                        for (k = 1; k <= Constants.SIZECONSTS.NPARKTYPES; k++)
                        {
                            parksp_n[k, n] = parksp_n[k, n] + parksp_p[k, p];
                            totallu_n[n] = totallu_n[n] + parksp_p[k, p];
                        }
                        for (k = 1; k <= Constants.SIZECONSTS.NPARKTYPES; k++)
                        {
                            parkpr_n[k, n] = parkpr_n[k, n] + parkpr_p[k, p] * parksp_p[k, p];
                        }
                    }
                }

                //Update parking prices as averages
                for (n = 1; n <= nnodes; n++)
                {
                    for (k = 1; k <= Constants.SIZECONSTS.NPARKTYPES; k++) parkpr_n[k, n] = parkpr_n[k, n] / (parksp_n[k, n] + 0.000000001);
                }

                for (i = 1; i <= nintsecs; i++)
                {
                    if (i % 10000 == 0) Console.WriteLine("Processed {0} intersection records", i);
                    n = nodeind_i[i];
                    if (n > 0)
                    {
                       if(links_i[i]==1) nodes1_n[n] = nodes1_n[n]+1; else 
                           if(links_i[i]==3) nodes3_n[n] = nodes3_n[n]+1; else 
                               if(links_i[i]>3) nodes4_n[n] = nodes4_n[n]+1;
                       totallu_n[n] = totallu_n[n] + 1;
                    }
                }

                using (StreamWriter extnodeWriter = new StreamWriter(ExtendedNodeFileName))
                {
                    processLogger.log("Started writing extended node file");
                    string[] header_arr = { "nodeid", "xcoord_n", "ycoord_n", "sqft_n", "totallu_n", "hh_n", "stugrd_n", "stuhgh_n", "stuuni_n", "empedu_n",
                                        "empfoo_n", "empgov_n", "empind_n", "empmed_n", "empofc_n", "empret_n", "empsvc_n", "empoth_n", "emptot_n", "parkdy_n",
                                          "parkhr_n", "ppricdyn", "pprichrn", "nodes1_n", "nodes3_n", "nodes4_n"};
                    extnodeWriter.WriteLine(string.Join(Constants.DELIMITERS.OUT_DELIMITER, header_arr));
                    for (n = 1; n <= nnodes; n++)
                    {
                        if (n % 10000 == 0) Console.WriteLine("Wrote {0} records", n);
                        extnodeWriter.Write(nodeid[n] + Constants.DELIMITERS.OUT_DELIMITER);
                        extnodeWriter.Write(xcoord_n[n] + Constants.DELIMITERS.OUT_DELIMITER);
                        extnodeWriter.Write(ycoord_n[n] + Constants.DELIMITERS.OUT_DELIMITER);
                        extnodeWriter.Write(sqft_n[n] + Constants.DELIMITERS.OUT_DELIMITER);
                        extnodeWriter.Write(totallu_n[n] + Constants.DELIMITERS.OUT_DELIMITER);
                        for (k = 1; k <= Constants.SIZECONSTS.NLUSEVARS; k++) extnodeWriter.Write(luse_n[k, n] + Constants.DELIMITERS.OUT_DELIMITER);
                        for (k = 1; k <= Constants.SIZECONSTS.NPARKTYPES; k++) extnodeWriter.Write(parksp_n[k, n] + Constants.DELIMITERS.OUT_DELIMITER);
                        for (k = 1; k <= Constants.SIZECONSTS.NPARKTYPES; k++) extnodeWriter.Write(parkpr_n[k, n] + Constants.DELIMITERS.OUT_DELIMITER); //use average price
                        extnodeWriter.Write(nodes1_n[n] + Constants.DELIMITERS.OUT_DELIMITER);
                        extnodeWriter.Write(nodes3_n[n] + Constants.DELIMITERS.OUT_DELIMITER);
                        extnodeWriter.Write(nodes4_n[n]);
                        extnodeWriter.Write("\n");
                    }
                    processLogger.log("Finished writing extended node file");
                }
                
            }
        }

        private double pythagDist(double x1,double y1,double x2,double y2)
        {
            //calculate pathagorean distance to the nearest foot
            return Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
        }

        private void precalculateDistanceDecayWeights() //set buffer weights for both buffers
        {
            int xydist;
            //pre-calculate buffer weights for each foot of distance
            for (xydist = 0; xydist <= Math.Round(Constants.BUFFPARAMS.BUFFDLIMIT); xydist++)
            {
                if (BuffTyp == Constants.BUFFTYPE.LOGISTIC)
                {
                    //logistic decay - inflection at buffdist1
                    dDecayWeights[1,xydist] = Math.Min(1.0, (1.0 + Math.Exp(BuffDecay1 * -0.5 + BuffOffset1/5280)) / (1.0 + Math.Exp(BuffDecay1 *(xydist/BuffDist1 -0.5 - BuffOffset1/5280))));
                    //logistic decay - inflection at buffdist2
                    dDecayWeights[2, xydist] = Math.Min(1.0, (1.0 + Math.Exp(BuffDecay2 * -0.5 + BuffOffset2 / 5280)) / (1.0 + Math.Exp(BuffDecay2 * (xydist / BuffDist2 - 0.5 - BuffOffset2 / 5280))));
                }
                else if (BuffTyp == Constants.BUFFTYPE.EXPONENTIAL)
                {
                    //exponential decay
                    dDecayWeights[1, xydist] =  Math.Exp(BuffExp1 * xydist / 5280);
                    dDecayWeights[2, xydist] = Math.Exp(BuffExp2 * xydist / 5280);
                }
            }
        }

        private string[] getNNReaderRow(string line)
        {
            return (line).Split(Constants.DELIMITERS.IN_DELIMITERS.Split(new[] { '-' }), StringSplitOptions.RemoveEmptyEntries);
        }

        private void openNodeNodeDistanceFile()
        {
            int i;
            try
            {
                nnReader = new StreamReader(NodeDistanceFileName);
                processLogger.log("Reading node-node distance information from " + NodeDistanceFileName);
                nnReader.ReadLine(); //header
                i = 0;
                currNodeOrd = 0;
                nnReaderRow = getNNReaderRow(nnReader.ReadLine());
                i = Convert.ToInt32(nnReaderRow[1]);
                while (i<=0 || nodeord[i]<=0)
                {
                    nnReaderRow = getNNReaderRow(nnReader.ReadLine());
                    i = Convert.ToInt32(nnReaderRow[1]);
                }
                nextNodeOrd = nodeord[i];

                NNIndexFileName = NodeDistanceFileName + ".index";
                NNIndexBinFileName = NodeDistanceFileName + ".bin";
                if(File.Exists(NNIndexFileName))
                {
                    writeNNfiles = false;
                }
                else
                {
                    writeNNfiles = true;
                    nindWriter = new StreamWriter(NNIndexFileName);
                    nindWriter.WriteLine("node_Id" + Constants.DELIMITERS.OUT_DELIMITER + "firstrec" + Constants.DELIMITERS.OUT_DELIMITER + "lastrec");
                    nindbinWriter = new BinaryWriter(File.Open(NNIndexBinFileName,FileMode.Create));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error opening Node distance file\n" + e.Message);
                processLogger.log(e.Message, "ERROR");
                throw e;
            }
        }

        private void closeNodeNodeDistanceFile()
        {
            nnReader.Close();
            if (writeNNfiles)
            {
                nindWriter.Close();
                nindbinWriter.Close();
            }
        }

        private void getNodeNodeDistances(int index)
        {
            nnDistance = new double[Constants.SIZECONSTS.MAXNODES+1];
            long onode, dnode, dnodeOrd, idist;
            double dist;
            string line;

            while (index > currNodeOrd)
            {
                for (dnode = 1; dnode <= Constants.SIZECONSTS.MAXNODES; dnode++) nnDistance[dnode] = -1;
                currNodeOrd = nextNodeOrd;
                onodefirstrec = 0;
                onodelastrec = 0;

                while (nextNodeOrd <= currNodeOrd)
                {
                    dnode = Convert.ToInt32(nnReaderRow[2]);
                    dist = Convert.ToDouble(nnReaderRow[3]);
                    if (nodeord[dnode] > 0 && dist < 99.0)
                    {
                        dnodeOrd = nodeord[dnode];
                        nnDistance[dnodeOrd] = dist * 5280;
                        if (writeNNfiles && currNodeOrd <= dnodeOrd)
                        {
                            idist = Convert.ToInt64(Math.Round(nnDistance[dnodeOrd]));
                            nindbinWriter.Write(dnodeOrd);
                            nindbinWriter.Write(idist);
                            dnodeswritten += 1;
                            if (onodefirstrec == 0) onodefirstrec = dnodeswritten;
                            onodelastrec = dnodeswritten;
                        }
                    }
                    if ((line = nnReader.ReadLine()) == null) nextNodeOrd = nnodes + 1;
                    else
                    {
                        nnReaderRow = getNNReaderRow(line);
                        onode = Convert.ToInt64(nnReaderRow[1]);
                        nextNodeOrd = nodeord[onode];
                    }
                }
                if (writeNNfiles)
                {
                    nindWriter.WriteLine(currNodeOrd + Constants.DELIMITERS.OUT_DELIMITER + onodefirstrec + Constants.DELIMITERS.OUT_DELIMITER + onodelastrec);
                    onodeswritten += 1;
                    for (onode = currNodeOrd + 1; onode <= (nextNodeOrd - 1); onode++)
                    {
                        nindWriter.WriteLine(onode + Constants.DELIMITERS.OUT_DELIMITER + 0 + Constants.DELIMITERS.OUT_DELIMITER + 0);
                        onodeswritten += 1;
                    }
                }
            }
        }

        private double nodeNodeDistance(int n1, int n2)
        {
            if (n1 == currNodeOrd & n2 > 0) return nnDistance[n2];
            else return -1;
        }


        private void bufferAroundAPoint(double originx, double originy, int originindex, int sindex)
        {
            int j, k, n;
            double[] bweight = new double[Constants.SIZECONSTS.NBUFFERS+1];
            double xydist;

            //initialize parcel buffer measures
            for (j = 1; j <= Constants.SIZECONSTS.NBUFFERS; j++)
            {
                for (k = 1; k<=Constants.SIZECONSTS.NLUSEVARS; k++) luse_b[sindex,j,k] = 0;
                for (k = 1; k <= Constants.SIZECONSTS.NPARKTYPES; k++) parksp_b[sindex, j, k] = 0;
                for (k = 1; k <= Constants.SIZECONSTS.NPARKTYPES; k++) parkpr_b[sindex, j, k] = 0;
            }

            //initialize intersection buffer measures
            for (j = 1; j <= Constants.SIZECONSTS.NBUFFERS; j++)
            {
                nodes1[sindex, j] = 0;
                nodes3[sindex, j] = 0;
                nodes4[sindex, j] = 0;
            }

            //initialize transit stop buffer measures
            for (j = 1; j <= Constants.SIZECONSTS.NBUFFERS; j++) tstops[sindex, j] = 0;
            for (k = 1; k <= 5; k++) dist_tran[sindex, k] = 999.0;

            //initialize open space buffer measures
            for (j = 1; j <= Constants.SIZECONSTS.NBUFFERS; j++)
            {
                bparks[sindex, j] = 0;
                aparks[sindex, j] = 0;
            }
            dist_park[sindex] = 999.0;

            if (DistCalcType == Constants.DISTCALC.EUCLIDEAN | DistCalcType == Constants.DISTCALC.CIRCUITY)
            {
                //loop on all parcels and screen on orthogonal distance less than buffdlimit
                //if originindex<3 then writeln(prtf,'Start of parcels for node ',originindex);
                for (n = 1; n <= nparcels; n++)
                {
                    if (Math.Abs(originx - xcoord_p[n]) + Math.Abs(originy - ycoord_p[n]) < Constants.BUFFPARAMS.BUFFDLIMIT)
                    {
                        //distances
                        xydist = setDistance(originindex, nodeind_p[n], originx, originy, xcoord_p[n], ycoord_p[n]);
                        if (xydist < Constants.BUFFPARAMS.MAXFEET)
                        {
                            bweight = bufferWeights(xydist, sqft_p[n]);

                            //accumulate all buffer variables
                            for (j = 1; j <= Constants.SIZECONSTS.NBUFFERS; j++)
                            {
                                if (bweight[j] > Constants.BUFFPARAMS.TINY)
                                {
                                    for (k = 1; k <= Constants.SIZECONSTS.NLUSEVARS; k++)
                                    {
                                        luse_b[sindex, j, k] = luse_b[sindex, j, k] + (bweight[j] * luse_p[k, n]);
                                    }
                                    for (k = 1; k <= Constants.SIZECONSTS.NPARKTYPES; k++)
                                    {
                                        parksp_b[sindex, j, k] = parksp_b[sindex, j, k] + (bweight[j] * parksp_p[k, n]);
                                        parkpr_b[sindex, j, k] = parkpr_b[sindex, j, k] + (bweight[j] * parksp_p[k, n] * parkpr_p[k, n]); //also weight by number of spaces
                                    }

                                    //for psrc, add up type 19 parcels in bparks
                                    if (type_p[n] == 19 & Constants.CUSTOM.PSRC) bparks[sindex, j] = bparks[sindex, j] + bweight[j];
                                }
                            }
                        }
                    }
                }

                //loop on all intersections
                //if originindex<3 then writeln(prtf,'Start of intersections for node ',originindex);
                for (n = 1; n <= nintsecs; n++)
                {
                    if ((Math.Abs(originx - xcoord_i[n]) + Math.Abs(originy - ycoord_i[n])) < Constants.BUFFPARAMS.BUFFDLIMIT)
                    {
                        //distances
                        //writeln('I ',originindex,' ',n,' ',nodeind_i[n]);
                        xydist = setDistance(originindex, nodeind_i[n], originx, originy, xcoord_i[n], ycoord_i[n]);
                        if (xydist < Constants.BUFFPARAMS.MAXFEET)
                        {
                            bweight = bufferWeights(xydist, 0);
                            //accumulate all buffer variables
                            for (j = 1; j <= Constants.SIZECONSTS.NBUFFERS; j++)
                            {
                                if (bweight[j] > Constants.BUFFPARAMS.TINY)
                                {
                                    if (links_i[n] == 1) nodes1[sindex, j] = nodes1[sindex, j] + bweight[j];
                                    else if (links_i[n] == 3) nodes3[sindex, j] = nodes3[sindex, j] + bweight[j];
                                    else if (links_i[n] > 3) nodes4[sindex, j] = nodes4[sindex, j] + bweight[j];
                                }
                            }

                        }
                    }
                }
            }
            else
            {
                //loop on all nodes and screen on orthogonal distance less than buffdlimit
                //if originindex<3 then writeln(prtf,'Start of nodes for node ',originindex);
                for (n = 1; n <= nnodes; n++)
                {
                    if (totallu_n[n] > 0 & (Math.Abs(originx - xcoord_n[n]) + Math.Abs(originy - ycoord_n[n])) < Constants.BUFFPARAMS.BUFFDLIMIT * 1.5)
                    {
                        //distances
                        //{writeln('P ',originindex,' ',n,' ',nodeind_p[n]);}
                        xydist = setDistance(originindex,n,originx,originy,xcoord_n[n],ycoord_n[n]);
                        if (xydist < Constants.BUFFPARAMS.MAXFEET)
                        {
                            bweight = bufferWeights(xydist, sqft_n[n]);

                            //accumulate all buffer variables
                            for (j = 1; j <= Constants.SIZECONSTS.NBUFFERS; j++)
                            {
                                if (bweight[j] > Constants.BUFFPARAMS.TINY)
                                {
                                    for (k = 1; k <= Constants.SIZECONSTS.NLUSEVARS; k++)
                                    {
                                        luse_b[sindex, j, k] = luse_b[sindex, j, k] + (bweight[j] * luse_n[k, n]);
                                    }
                                    for (k = 1; k <= Constants.SIZECONSTS.NPARKTYPES; k++)
                                    {
                                        parksp_b[sindex, j, k] = parksp_b[sindex, j, k] + (bweight[j] * parksp_n[k, n]);
                                        parkpr_b[sindex, j, k] = parkpr_b[sindex, j, k] + (bweight[j] * parksp_n[k, n] * parkpr_n[k, n]); //also weight by number of spaces
                                    }
                                    nodes1[sindex, j] = nodes1[sindex, j] + bweight[j] * nodes1_n[n];
                                    nodes3[sindex, j] = nodes3[sindex, j] + bweight[j] * nodes3_n[n];
                                    nodes4[sindex, j] = nodes4[sindex, j] + bweight[j] * nodes4_n[n];
                                }
                            }
                        }
                    }
                }
            }

            //loop on all transit stops
            //if originindex<3 then writeln(prtf,'Start of transit stops for node ',originindex);
            for (n = 1; n <= nstops; n++)
            {
                if ((Math.Abs(originx - xcoord_s[n]) + Math.Abs(originy - ycoord_s[n])) < Constants.BUFFPARAMS.MAXFEET)
                {
                    //distances
                    //{writeln('S ',originindex,' ',n,' ',nodeind_s[n]);}
                    xydist = setDistance(originindex, nodeind_s[n], originx, originy, xcoord_s[n], ycoord_s[n]);

                    if(mode_s[n]>=1 & mode_s[n]<=5 & (xydist/5280.0 < dist_tran[sindex,mode_s[n]])) dist_tran[sindex,mode_s[n]] = xydist/5280.0;

                    if (xydist < Constants.BUFFPARAMS.BUFFDLIMIT & xydist < Constants.BUFFPARAMS.MAXFEET)
                    {
                        bweight = bufferWeights(xydist, 0);

                        //accumulate all buffer variables
                        for (j = 1; j <= Constants.SIZECONSTS.NBUFFERS; j++)
                        {
                            if (bweight[j] > Constants.BUFFPARAMS.TINY)
                            {
                                tstops[sindex, j] = tstops[sindex, j] + bweight[j];
                            }
                        }
                    }
                }
            }

            //loop on all park records
            //if originindex<3 then writeln(prtf,'Start of open space for node ',originindex);
            for (n = 1; n <= nparks; n++)
            {
                if (nparks < 100000 | (Math.Abs(originx - xcoord_o[n]) + Math.Abs(originy - ycoord_o[n])) < Constants.BUFFPARAMS.BUFFDLIMIT)
                {
                    //distances
                    //writeln('O ',originindex,' ',n,' ',nodeind_o[n]);
                    xydist = setDistance(originindex, nodeind_o[n], originx, originy, xcoord_o[n], ycoord_o[n]);

                    if (xydist < Constants.BUFFPARAMS.MAXFEET)
                    {
                        bweight = bufferWeights(xydist, sqft_o[n]);

                        //accumulate all buffer variables
                        for (j = 1; j <= Constants.SIZECONSTS.NBUFFERS; j++)
                        {
                            if (bweight[j] > Constants.BUFFPARAMS.TINY)
                            {
                                bparks[sindex, j] = bparks[sindex, j] + bweight[j];
                                aparks[sindex, j] = aparks[sindex, j] + (bweight[j] * sqft_o[n]);

                            }
                        }
                        xydist = xydist - Math.Sqrt(sqft_o[n] / 3.14); //adjust distance to edge of park, if park were a circle
                        if (xydist < 0) xydist = 0;
                        if (xydist / 5280.0 < dist_park[sindex]) dist_park[sindex] = xydist / 5280.0;
                    }
                }
            }

        }

        private double setDistance(int oindex, int dindex, double ox, double oy, double dx, double dy)
        {
            double xydist=-1;
            if (DistCalcType == Constants.DISTCALC.NODETONODE)
            {
                xydist = nodeNodeDistance(oindex, dindex);
                if (xydist < 0) xydist = Constants.BUFFPARAMS.DEFAULTCIRCRATIO * pythagDist(ox, oy, dx, dy);
            }
            else if (DistCalcType == Constants.DISTCALC.CIRCUITY)
            {
                xydist = circuityDist(oindex, ox, oy, dx, dy);
            }
            else xydist = pythagDist(ox, oy, dx, dy);
            return xydist;
        }

        private double circuityDist(int p_circ, double ox, double oy, double dx, double dy)
        {
            int oddir=99, oddi2;
            double xydist, angle=1, circuityRatio;
            double[] dwt = new double[Constants.SIZECONSTS.NDISTBANDS + 1];

            /* Octant   dx-ox   dx-oy   Xdif vs. Ydif
             1 E-NE     pos     pos     greater
             2 NE-N     pos     pos     less
             3 N-NW     neg     pos     less
             4 NW-W     neg     pos     greater
             5 W-SW     neg     neg     greater
             6 SW-S     neg     neg     less
             7 S-SE     pos     neg     less
             8 SE-E     pos     neg     greater
             */

            xydist = pythagDist(ox, oy, dx, dy);
            if (dx == ox & dy == oy) circuityRatio = 1.0;
            else
            {
                if (dy == oy) //due East or West
                {
                    if (dx > ox) //due E
                    {
                        oddir = 1;
                        angle = 0;
                    }
                    else //due W
                    {
                        oddir = 5;
                        angle = 0;
                    }
                }
                else if (dx == ox) //due N or S
                {
                    if (dy > oy) //due N
                    {
                        oddir = 3;
                        angle = 0;
                    }
                    else //due S
                    {
                        oddir = 7;
                        angle = 0;
                    }
                }
                else if (dy > oy) //towards North
                {
                    if (dx > ox) //NE quadrant
                    {
                        if (Math.Abs(dx - ox) > Math.Abs(dy - oy)) //E-NE
                        {
                            oddir = 1;
                            angle = Math.Abs(dy - oy) / Math.Abs(dx - ox);
                        }
                        else //NE-N
                        {
                            oddir = 2;
                            angle = 1.0 - Math.Abs(dx - ox) / Math.Abs(dy - oy);
                        }
                    }
                    else //NW quadrant
                    {
                        if (Math.Abs(dx - ox) < Math.Abs(dy - oy)) //N-NW
                        {
                            oddir = 3;
                            angle = Math.Abs(dx - ox) / Math.Abs(dy - oy);
                        }
                        else
                        {
                            oddir = 4;
                            angle = 1.0 - Math.Abs(dy - oy) / Math.Abs(dx - ox);
                        }
                    }
                }
                else //towards South
                {
                    if (dx < ox) //SW quadrant
                    {
                        if (Math.Abs(dx - ox) > Math.Abs(dy - oy)) //W-SW
                        {
                            oddir = 5;
                            angle = Math.Abs(dy - oy) / Math.Abs(dx - ox);
                        }
                        else //SW-S
                        {
                            oddir = 6;
                            angle = 1.0 - Math.Abs(dx - ox) / Math.Abs(dy - oy);
                        }
                    }
                    else //SE quadrant
                    {
                        if (Math.Abs(dx - ox) < Math.Abs(dy - oy)) //S-SE
                        {
                            oddir = 7;
                            angle = Math.Abs(dx - ox) / Math.Abs(dy - oy);
                        }
                        else //SE-E
                        {
                            oddir = 8;
                            angle = 1.0 - Math.Abs(dy - oy) / Math.Abs(dx - ox);
                        }
                    }

                }
                if (xydist < Constants.BUFFPARAMS.DISTLIMIT1)
                {
                    dwt[1] = 1.0;
                    dwt[2] = 0.0;
                    dwt[3] = 0.0;
                }
                else if (xydist < Constants.BUFFPARAMS.DISTLIMIT2)
                {
                    dwt[2] = (xydist - Constants.BUFFPARAMS.DISTLIMIT1) / (Constants.BUFFPARAMS.DISTLIMIT2 - Constants.BUFFPARAMS.DISTLIMIT1);
                    dwt[1] = 1.0 - dwt[2];
                    dwt[3] = 0.0;
                }
                else if (xydist < Constants.BUFFPARAMS.DISTLIMIT3)
                {
                    dwt[3] = (xydist - Constants.BUFFPARAMS.DISTLIMIT2) / (Constants.BUFFPARAMS.DISTLIMIT3 - Constants.BUFFPARAMS.DISTLIMIT2);
                    dwt[2] = 1.0 - dwt[3];
                    dwt[1] = 0.0;
                }
                if (xydist >= Constants.BUFFPARAMS.DISTLIMIT3)
                {
                    dwt[3] = 1.0;
                    dwt[2] = 0.0;
                    dwt[1] = 0.0;
                }

                if (oddir < Constants.SIZECONSTS.NDIRECTIONS) oddi2 = oddir + 1; else oddi2 = 1;

                circuityRatio = (1 - angle) * (dwt[1] * circValue[p_circ, oddir, 1] + dwt[2] * circValue[p_circ, oddir, 2] + dwt[3] * circValue[p_circ, oddir, 3]) +
                                     angle * (dwt[1] * circValue[p_circ, oddi2, 1] + dwt[2] * circValue[p_circ, oddi2, 2] + dwt[3] * circValue[p_circ, oddi2, 3]);
            }

            if (xydist < Constants.BUFFPARAMS.MAXCIRCDIST) return circuityRatio * xydist;
            else
            {
                //default ratio, around sqrt(2), applied to portion of distance over maxCircDist
                return circuityRatio * Constants.BUFFPARAMS.MAXCIRCDIST + Constants.BUFFPARAMS.DEFAULTCIRCRATIO * (xydist - Constants.BUFFPARAMS.MAXCIRCDIST);
            }
        }


        private double[] bufferWeights(double xydist, double sqft)
        {
            double[] buffwts = new double[Constants.SIZECONSTS.NBUFFERS+1];
            //set buffer weights for both buffers
            double dwidth, xydistf, xydistn;
            dwidth = 1;
            xydistf = xydist;
            xydistn = xydist;
            if (BuffTyp == Constants.BUFFTYPE.FLAT)
            {
                if (sqft > 0)
                {
                    //approximate distance to near near and far parcel boundaries
                    dwidth = Math.Sqrt(sqft);
                    xydistf = xydist + dwidth / 2.0;
                    xydistn = xydist - dwidth / 2.0;
                }
            }

            if (BuffTyp != Constants.BUFFTYPE.FLAT) buffwts[1] = dDecayWeights[1, Convert.ToInt32(Math.Round(xydist))]; //decay buffer - use pre-calculated value
            else if (xydistf <= BuffDist1) buffwts[1] = 1; //flat buffer - full parcel within limit
            else if (xydistn > BuffDist1) buffwts[1] = 0; //flat buffer - full parcel outside limit
            else buffwts[1] = Math.Min(1.0, (BuffDist1 - xydistn) / dwidth); //flat buffer - part of parcel within limit

            if (BuffTyp != Constants.BUFFTYPE.FLAT) buffwts[2] = dDecayWeights[2, Convert.ToInt32(Math.Round(xydist))]; //decay buffer - use pre-calculated value
            else if (xydistf <= BuffDist2) buffwts[2] = 1; //flat buffer - full parcel within limit
            else if (xydistn > BuffDist2) buffwts[2] = 0; //flat buffer - full parcel outside limit
            else buffwts[2] = Math.Min(1.0, (BuffDist2 - xydistn) / dwidth); //flat buffer - part of parcel within limit

            return buffwts;
        }

        private void getBuffParams()
        {
            if (rdbEuclidean.Checked) DistCalcType = Constants.DISTCALC.EUCLIDEAN;
            else if (rdbCircuity.Checked) DistCalcType = Constants.DISTCALC.CIRCUITY;
            else if (rdbNode.Checked) DistCalcType = Constants.DISTCALC.NODETONODE;

            ParcelFileName = txtParcelData.Text;
            IntersectionFileName = txtIntersection.Text;
            TransitStopsFileName = txtTransitStops.Text;
            OpenSpacesFileName = txtOpenSpaces.Text;
            CircuityFileName = txtCircuity.Text;
            NodeFileName = txtNodeData.Text;
            NodeDistanceFileName = txtNodeDistance.Text;
            ExtendedNodeFileName = txtExtNode.Text;
            ParcelNodeFileName = txtParcelNode.Text;
            IntNodeFileName = txtIntNode.Text;
            StopNodeFileName = txtStopNode.Text;
            OpenNodeFileName = txtOpenSpacesNode.Text;

            if (rdbBuffTypFlat.Checked) BuffTyp = Constants.BUFFTYPE.FLAT;
            else if (rdbBuffTypLog.Checked) BuffTyp = Constants.BUFFTYPE.LOGISTIC;
            else if (rdbBuffTypExp.Checked) BuffTyp = Constants.BUFFTYPE.EXPONENTIAL;

            BuffDist1 = Convert.ToDouble(txtBuffDist1.Text);
            BuffDecay1 = Convert.ToDouble(txtBuffDecay1.Text);
            BuffExp1 = Convert.ToDouble(txtBuffExp1.Text);
            BuffOffset1 = Convert.ToDouble(txtBuffOffset1.Text);

            BuffDist2 = Convert.ToDouble(txtBuffDist2.Text);
            BuffDecay2 = Convert.ToDouble(txtBuffDecay2.Text);
            BuffExp2 = Convert.ToDouble(txtBuffExp2.Text);
            BuffOffset2 = Convert.ToDouble(txtBuffOffset2.Text);

            ParcelOutputFileName = txtOutputParcel.Text;
            OutputXMLFileName = txtXMLOutput.Text;
        }

        private void startLog()
        {
            if (OutputXMLFileName == null)
            {
                processLogger = new Logger();
            }
            else
            {
                string xmlfilebase = OutputXMLFileName.Split(new string[]{".XML",".xml"}, StringSplitOptions.RemoveEmptyEntries)[0];
                string logfilename = xmlfilebase + "_log.txt";
                processLogger = new Logger(logfilename);
            }
            processLogger.log("Started buffering process");
            Console.WriteLine("Writing to log file: " +  processLogger.LogFileName);
        }

        private void btnBrowseParcelData_Click(object sender, EventArgs e)
        {
            OpenFileDialog openParcelDataFileDialog = new OpenFileDialog();
            openParcelDataFileDialog.Filter = "dat files (*.dat)|*.dat|All files (*.*)|*.*";
            openParcelDataFileDialog.Title = "Select Parcel File";
            openParcelDataFileDialog.FilterIndex = 2;

            if (openParcelDataFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtParcelData.Text = openParcelDataFileDialog.FileName;
            }
        }

        private void btnBrowseXML_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openXMLFileDialog = new OpenFileDialog();
                openXMLFileDialog.Filter = "XML files (*.xml)|*.xml";
                openXMLFileDialog.Title = "Select Input XML File";
                string xmlInputFile = openXMLFileDialog.FileName; // default

                if (openXMLFileDialog.ShowDialog() == DialogResult.OK) xmlInputFile = openXMLFileDialog.FileName;
                else
                {
                    MessageBox.Show("No file selected");
                    return;
                }
                txtXMLInput.Text = xmlInputFile;
                readXmlFile(xmlInputFile);
            }

            catch (System.IO.IOException error)
            {
                MessageBox.Show("Error: " + error.Message);
                processLogger.log(error.Message, "ERROR");
                return;
            }

        }

        private void btnBrowseIntersection_Click(object sender, EventArgs e)
        {
            OpenFileDialog openIntersectionFileDialog = new OpenFileDialog();
            openIntersectionFileDialog.Filter = "dat files (*.dat)|*.dat|All files (*.*)|*.*";
            openIntersectionFileDialog.Title = "Select Intersection File";
            openIntersectionFileDialog.FilterIndex = 2;

            if (openIntersectionFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtIntersection.Text = openIntersectionFileDialog.FileName;
            }
        }

        private void btnBrowseTransitStops_Click(object sender, EventArgs e)
        {
            OpenFileDialog openTransitStopsFileDialog = new OpenFileDialog();
            openTransitStopsFileDialog.Filter = "dat files (*.dat)|*.dat|All files (*.*)|*.*";
            openTransitStopsFileDialog.Title = "Select Transit Stops File";
            openTransitStopsFileDialog.FilterIndex = 2;

            if (openTransitStopsFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtTransitStops.Text = openTransitStopsFileDialog.FileName;
            }
        }

        private void btnBrowseOpenSpaces_Click(object sender, EventArgs e)
        {
            OpenFileDialog openOpenSpacesFileDialog = new OpenFileDialog();
            openOpenSpacesFileDialog.Filter = "dat files (*.dat)|*.dat|All files (*.*)|*.*";
            openOpenSpacesFileDialog.Title = "Select Open Spaces File";
            openOpenSpacesFileDialog.FilterIndex = 2;

            if (openOpenSpacesFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtOpenSpaces.Text = openOpenSpacesFileDialog.FileName;
            }
        }

        private void btnBrowseCircuity_Click(object sender, EventArgs e)
        {
            OpenFileDialog openCircuityFileDialog = new OpenFileDialog();
            openCircuityFileDialog.Filter = "dat files (*.dat)|*.dat|All files (*.*)|*.*";
            openCircuityFileDialog.Title = "Select Circuity File";
            openCircuityFileDialog.FilterIndex = 2;

            if (openCircuityFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtCircuity.Text = openCircuityFileDialog.FileName;
            }
        }

        private void btnBrowseNodeData_Click(object sender, EventArgs e)
        {
            OpenFileDialog openNodeFileDialog = new OpenFileDialog();
            openNodeFileDialog.Filter = "dat files (*.dat)|*.dat|All files (*.*)|*.*";
            openNodeFileDialog.Title = "Select Node File";
            openNodeFileDialog.FilterIndex = 2;

            if (openNodeFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtNodeData.Text = openNodeFileDialog.FileName;
            }
        }

        private void btnBrowseNodeDistance_Click(object sender, EventArgs e)
        {
            OpenFileDialog openNodeDistanceFileDialog = new OpenFileDialog();
            openNodeDistanceFileDialog.Filter = "dat files (*.dat)|*.dat|All files (*.*)|*.*";
            openNodeDistanceFileDialog.Title = "Select Node Distance File";
            openNodeDistanceFileDialog.FilterIndex = 2;

            if (openNodeDistanceFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtNodeDistance.Text = openNodeDistanceFileDialog.FileName;
            }
        }

        private void btnBrowseOutput_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveOutputParcelFileDialog = new SaveFileDialog();
            saveOutputParcelFileDialog.Filter = "dat files (*.dat)|*.dat|All files (*.*)|*.*";
            saveOutputParcelFileDialog.Title = "Output Parcel File";

            if (saveOutputParcelFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtOutputParcel.Text = saveOutputParcelFileDialog.FileName;
            }
        }

        private void btnBrowseExtNode_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveExtNodeFileDialog = new SaveFileDialog();
            saveExtNodeFileDialog.OverwritePrompt = false;
            saveExtNodeFileDialog.Filter = "dat files (*.dat)|*.dat|All files (*.*)|*.*";
            saveExtNodeFileDialog.Title = "Extended Node File";

            if (saveExtNodeFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtExtNode.Text = saveExtNodeFileDialog.FileName;
            }
        }

        private void btnBrowseParcelNode_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveParcelNodeFileDialog = new SaveFileDialog();
            saveParcelNodeFileDialog.OverwritePrompt = false;
            saveParcelNodeFileDialog.Filter = "dat files (*.dat)|*.dat|All files (*.*)|*.*";
            saveParcelNodeFileDialog.Title = "Extended Node File";

            if (saveParcelNodeFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtParcelNode.Text = saveParcelNodeFileDialog.FileName;
            }
        }

        private void btnBrowseIntNode_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveIntNodeFileDialog = new SaveFileDialog();
            saveIntNodeFileDialog.OverwritePrompt = false;
            saveIntNodeFileDialog.Filter = "dat files (*.dat)|*.dat|All files (*.*)|*.*";
            saveIntNodeFileDialog.Title = "Extended Node File";

            if (saveIntNodeFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtIntNode.Text = saveIntNodeFileDialog.FileName;
            }
        }

        private void btnBrowseStopNode_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveStopNodeFileDialog = new SaveFileDialog();
            saveStopNodeFileDialog.OverwritePrompt = false;
            saveStopNodeFileDialog.Filter = "dat files (*.dat)|*.dat|All files (*.*)|*.*";
            saveStopNodeFileDialog.Title = "Extended Node File";

            if (saveStopNodeFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtStopNode.Text = saveStopNodeFileDialog.FileName;
            }
        }

        private void btnBrowseOpenSpacesNode_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveOpenSpacesNodeFileDialog = new SaveFileDialog();
            saveOpenSpacesNodeFileDialog.OverwritePrompt = false;
            saveOpenSpacesNodeFileDialog.Filter = "dat files (*.dat)|*.dat|All files (*.*)|*.*";
            saveOpenSpacesNodeFileDialog.Title = "Extended Node File";

            if (saveOpenSpacesNodeFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtOpenSpacesNode.Text = saveOpenSpacesNodeFileDialog.FileName;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "DaySim Buffering Tool", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            switch (result)
            {
                case DialogResult.Yes:
                    Application.Exit();
                    break;
                default:
                    // Return from the FormClosing method
                    return;
            }
        }

        private void btnBrowseXMLOutput_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveOutputXMLFileDialog = new SaveFileDialog();
            saveOutputXMLFileDialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            saveOutputXMLFileDialog.Title = "Output XML File";

            if (saveOutputXMLFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtXMLOutput.Text = saveOutputXMLFileDialog.FileName;
            }
        }

        private void rdbDistType_CheckedChanged(object sender, EventArgs e)
        {
            txtCircuity.Enabled = rdbCircuity.Checked;
            btnBrowseCircuity.Enabled = rdbCircuity.Checked;
            txtNodeData.Enabled = rdbNode.Checked;
            btnBrowseNodeData.Enabled = rdbNode.Checked;
            txtNodeDistance.Enabled = rdbNode.Checked;
            btnBrowseNodeDistance.Enabled = rdbNode.Checked;
            txtExtNode.Enabled = rdbNode.Checked;
            btnBrowseExtNode.Enabled = rdbNode.Checked;
            txtParcelNode.Enabled = rdbNode.Checked;
            btnBrowseParcelNode.Enabled = rdbNode.Checked;
            txtIntNode.Enabled = rdbNode.Checked;
            btnBrowseIntNode.Enabled = rdbNode.Checked;
            txtStopNode.Enabled = rdbNode.Checked;
            btnBrowseStopNode.Enabled = rdbNode.Checked;
            txtOpenSpacesNode.Enabled = rdbNode.Checked;
            btnBrowseOpenSpacesNode.Enabled = rdbNode.Checked;
        }

        private void rdbBuffType_CheckedChanged(object sender, EventArgs e)
        {
            txtBuffDecay1.Enabled = rdbBuffTypLog.Checked;
            txtBuffDecay2.Enabled = rdbBuffTypLog.Checked;
            txtBuffOffset1.Enabled = rdbBuffTypLog.Checked;
            txtBuffOffset2.Enabled = rdbBuffTypLog.Checked;
            txtBuffExp1.Enabled = rdbBuffTypExp.Checked;
            txtBuffExp2.Enabled = rdbBuffTypExp.Checked;
        }

        private void txtTransitStops_TextChanged(object sender, EventArgs e)
        {

        }        

    }
}
