namespace DSBuffTool
{
    partial class DSBuff
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRun = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblXMLInput = new System.Windows.Forms.Label();
            this.txtXMLInput = new System.Windows.Forms.TextBox();
            this.gbInputs = new System.Windows.Forms.GroupBox();
            this.btnBrowseOpenSpacesNode = new System.Windows.Forms.Button();
            this.txtOpenSpacesNode = new System.Windows.Forms.TextBox();
            this.lblOpenSpacesNode = new System.Windows.Forms.Label();
            this.btnBrowseStopNode = new System.Windows.Forms.Button();
            this.txtStopNode = new System.Windows.Forms.TextBox();
            this.lblStopNode = new System.Windows.Forms.Label();
            this.btnBrowseIntNode = new System.Windows.Forms.Button();
            this.txtIntNode = new System.Windows.Forms.TextBox();
            this.lblIntNode = new System.Windows.Forms.Label();
            this.btnBrowseExtNode = new System.Windows.Forms.Button();
            this.txtExtNode = new System.Windows.Forms.TextBox();
            this.lblExtNode = new System.Windows.Forms.Label();
            this.btnBrowseParcelNode = new System.Windows.Forms.Button();
            this.txtParcelNode = new System.Windows.Forms.TextBox();
            this.lblParcelNode = new System.Windows.Forms.Label();
            this.lblBufferType = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdbBuffTypExp = new System.Windows.Forms.RadioButton();
            this.rdbBuffTypLog = new System.Windows.Forms.RadioButton();
            this.rdbBuffTypFlat = new System.Windows.Forms.RadioButton();
            this.lblDistCalc = new System.Windows.Forms.Label();
            this.rdbNode = new System.Windows.Forms.RadioButton();
            this.rdbCircuity = new System.Windows.Forms.RadioButton();
            this.rdbEuclidean = new System.Windows.Forms.RadioButton();
            this.txtBuffOffset2 = new System.Windows.Forms.TextBox();
            this.lblBuffOffset2 = new System.Windows.Forms.Label();
            this.txtBuffExp2 = new System.Windows.Forms.TextBox();
            this.lblBuffExp2 = new System.Windows.Forms.Label();
            this.txtBuffDecay2 = new System.Windows.Forms.TextBox();
            this.lblBuffDecay2 = new System.Windows.Forms.Label();
            this.txtBuffDist2 = new System.Windows.Forms.TextBox();
            this.lblBuffDist2 = new System.Windows.Forms.Label();
            this.txtBuffOffset1 = new System.Windows.Forms.TextBox();
            this.lblBuffOffset1 = new System.Windows.Forms.Label();
            this.txtBuffExp1 = new System.Windows.Forms.TextBox();
            this.lblBuffExp1 = new System.Windows.Forms.Label();
            this.txtBuffDecay1 = new System.Windows.Forms.TextBox();
            this.lblBuffDecay1 = new System.Windows.Forms.Label();
            this.txtBuffDist1 = new System.Windows.Forms.TextBox();
            this.lblBuffDist1 = new System.Windows.Forms.Label();
            this.btnBrowseNodeDistance = new System.Windows.Forms.Button();
            this.txtNodeDistance = new System.Windows.Forms.TextBox();
            this.lblNodeDistance = new System.Windows.Forms.Label();
            this.btnBrowseNodeData = new System.Windows.Forms.Button();
            this.txtNodeData = new System.Windows.Forms.TextBox();
            this.lblNodeData = new System.Windows.Forms.Label();
            this.btnBrowseCircuity = new System.Windows.Forms.Button();
            this.txtCircuity = new System.Windows.Forms.TextBox();
            this.lblCircuity = new System.Windows.Forms.Label();
            this.btnBrowseOpenSpaces = new System.Windows.Forms.Button();
            this.txtOpenSpaces = new System.Windows.Forms.TextBox();
            this.lblOpenSpaces = new System.Windows.Forms.Label();
            this.btnBrowseTransitStops = new System.Windows.Forms.Button();
            this.txtTransitStops = new System.Windows.Forms.TextBox();
            this.lblTransitStops = new System.Windows.Forms.Label();
            this.btnBrowseIntersection = new System.Windows.Forms.Button();
            this.txtIntersection = new System.Windows.Forms.TextBox();
            this.lblIntersection = new System.Windows.Forms.Label();
            this.btnBrowseParcelData = new System.Windows.Forms.Button();
            this.txtParcelData = new System.Windows.Forms.TextBox();
            this.lblParcelData = new System.Windows.Forms.Label();
            this.gbReadXML = new System.Windows.Forms.GroupBox();
            this.btnBrowseXMLInput = new System.Windows.Forms.Button();
            this.gbOutputs = new System.Windows.Forms.GroupBox();
            this.btnBrowseXMLOutput = new System.Windows.Forms.Button();
            this.txtXMLOutput = new System.Windows.Forms.TextBox();
            this.lblXMLOutput = new System.Windows.Forms.Label();
            this.btnBrowseOutputParcel = new System.Windows.Forms.Button();
            this.txtOutputParcel = new System.Windows.Forms.TextBox();
            this.lblOutputParcel = new System.Windows.Forms.Label();
            this.gbInputs.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbReadXML.SuspendLayout();
            this.gbOutputs.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(441, 732);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(95, 27);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.Run_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(244, 732);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 27);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblXMLInput
            // 
            this.lblXMLInput.AutoSize = true;
            this.lblXMLInput.Location = new System.Drawing.Point(22, 30);
            this.lblXMLInput.Name = "lblXMLInput";
            this.lblXMLInput.Size = new System.Drawing.Size(75, 13);
            this.lblXMLInput.TabIndex = 2;
            this.lblXMLInput.Text = "XML Input File";
            // 
            // txtXMLInput
            // 
            this.txtXMLInput.Location = new System.Drawing.Point(226, 26);
            this.txtXMLInput.Name = "txtXMLInput";
            this.txtXMLInput.Size = new System.Drawing.Size(457, 20);
            this.txtXMLInput.TabIndex = 3;
            // 
            // gbInputs
            // 
            this.gbInputs.Controls.Add(this.btnBrowseOpenSpacesNode);
            this.gbInputs.Controls.Add(this.txtOpenSpacesNode);
            this.gbInputs.Controls.Add(this.lblOpenSpacesNode);
            this.gbInputs.Controls.Add(this.btnBrowseStopNode);
            this.gbInputs.Controls.Add(this.txtStopNode);
            this.gbInputs.Controls.Add(this.lblStopNode);
            this.gbInputs.Controls.Add(this.btnBrowseIntNode);
            this.gbInputs.Controls.Add(this.txtIntNode);
            this.gbInputs.Controls.Add(this.lblIntNode);
            this.gbInputs.Controls.Add(this.btnBrowseExtNode);
            this.gbInputs.Controls.Add(this.txtExtNode);
            this.gbInputs.Controls.Add(this.lblExtNode);
            this.gbInputs.Controls.Add(this.btnBrowseParcelNode);
            this.gbInputs.Controls.Add(this.txtParcelNode);
            this.gbInputs.Controls.Add(this.lblParcelNode);
            this.gbInputs.Controls.Add(this.lblBufferType);
            this.gbInputs.Controls.Add(this.panel1);
            this.gbInputs.Controls.Add(this.lblDistCalc);
            this.gbInputs.Controls.Add(this.rdbNode);
            this.gbInputs.Controls.Add(this.rdbCircuity);
            this.gbInputs.Controls.Add(this.rdbEuclidean);
            this.gbInputs.Controls.Add(this.txtBuffOffset2);
            this.gbInputs.Controls.Add(this.lblBuffOffset2);
            this.gbInputs.Controls.Add(this.txtBuffExp2);
            this.gbInputs.Controls.Add(this.lblBuffExp2);
            this.gbInputs.Controls.Add(this.txtBuffDecay2);
            this.gbInputs.Controls.Add(this.lblBuffDecay2);
            this.gbInputs.Controls.Add(this.txtBuffDist2);
            this.gbInputs.Controls.Add(this.lblBuffDist2);
            this.gbInputs.Controls.Add(this.txtBuffOffset1);
            this.gbInputs.Controls.Add(this.lblBuffOffset1);
            this.gbInputs.Controls.Add(this.txtBuffExp1);
            this.gbInputs.Controls.Add(this.lblBuffExp1);
            this.gbInputs.Controls.Add(this.txtBuffDecay1);
            this.gbInputs.Controls.Add(this.lblBuffDecay1);
            this.gbInputs.Controls.Add(this.txtBuffDist1);
            this.gbInputs.Controls.Add(this.lblBuffDist1);
            this.gbInputs.Controls.Add(this.btnBrowseNodeDistance);
            this.gbInputs.Controls.Add(this.txtNodeDistance);
            this.gbInputs.Controls.Add(this.lblNodeDistance);
            this.gbInputs.Controls.Add(this.btnBrowseNodeData);
            this.gbInputs.Controls.Add(this.txtNodeData);
            this.gbInputs.Controls.Add(this.lblNodeData);
            this.gbInputs.Controls.Add(this.btnBrowseCircuity);
            this.gbInputs.Controls.Add(this.txtCircuity);
            this.gbInputs.Controls.Add(this.lblCircuity);
            this.gbInputs.Controls.Add(this.btnBrowseOpenSpaces);
            this.gbInputs.Controls.Add(this.txtOpenSpaces);
            this.gbInputs.Controls.Add(this.lblOpenSpaces);
            this.gbInputs.Controls.Add(this.btnBrowseTransitStops);
            this.gbInputs.Controls.Add(this.txtTransitStops);
            this.gbInputs.Controls.Add(this.lblTransitStops);
            this.gbInputs.Controls.Add(this.btnBrowseIntersection);
            this.gbInputs.Controls.Add(this.txtIntersection);
            this.gbInputs.Controls.Add(this.lblIntersection);
            this.gbInputs.Controls.Add(this.btnBrowseParcelData);
            this.gbInputs.Controls.Add(this.txtParcelData);
            this.gbInputs.Controls.Add(this.lblParcelData);
            this.gbInputs.Location = new System.Drawing.Point(12, 81);
            this.gbInputs.Name = "gbInputs";
            this.gbInputs.Size = new System.Drawing.Size(762, 571);
            this.gbInputs.TabIndex = 4;
            this.gbInputs.TabStop = false;
            this.gbInputs.Text = "INPUT";
            // 
            // btnBrowseOpenSpacesNode
            // 
            this.btnBrowseOpenSpacesNode.Enabled = false;
            this.btnBrowseOpenSpacesNode.Location = new System.Drawing.Point(696, 364);
            this.btnBrowseOpenSpacesNode.Name = "btnBrowseOpenSpacesNode";
            this.btnBrowseOpenSpacesNode.Size = new System.Drawing.Size(60, 20);
            this.btnBrowseOpenSpacesNode.TabIndex = 65;
            this.btnBrowseOpenSpacesNode.Text = "Browse";
            this.btnBrowseOpenSpacesNode.UseVisualStyleBackColor = true;
            this.btnBrowseOpenSpacesNode.Click += new System.EventHandler(this.btnBrowseOpenSpacesNode_Click);
            // 
            // txtOpenSpacesNode
            // 
            this.txtOpenSpacesNode.Enabled = false;
            this.txtOpenSpacesNode.Location = new System.Drawing.Point(227, 363);
            this.txtOpenSpacesNode.Name = "txtOpenSpacesNode";
            this.txtOpenSpacesNode.Size = new System.Drawing.Size(457, 20);
            this.txtOpenSpacesNode.TabIndex = 64;
            // 
            // lblOpenSpacesNode
            // 
            this.lblOpenSpacesNode.AutoSize = true;
            this.lblOpenSpacesNode.Location = new System.Drawing.Point(22, 368);
            this.lblOpenSpacesNode.Name = "lblOpenSpacesNode";
            this.lblOpenSpacesNode.Size = new System.Drawing.Size(201, 13);
            this.lblOpenSpacesNode.TabIndex = 63;
            this.lblOpenSpacesNode.Text = "Open Spaces-Node Correspondence File";
            // 
            // btnBrowseStopNode
            // 
            this.btnBrowseStopNode.Enabled = false;
            this.btnBrowseStopNode.Location = new System.Drawing.Point(696, 338);
            this.btnBrowseStopNode.Name = "btnBrowseStopNode";
            this.btnBrowseStopNode.Size = new System.Drawing.Size(60, 20);
            this.btnBrowseStopNode.TabIndex = 62;
            this.btnBrowseStopNode.Text = "Browse";
            this.btnBrowseStopNode.UseVisualStyleBackColor = true;
            this.btnBrowseStopNode.Click += new System.EventHandler(this.btnBrowseStopNode_Click);
            // 
            // txtStopNode
            // 
            this.txtStopNode.Enabled = false;
            this.txtStopNode.Location = new System.Drawing.Point(227, 337);
            this.txtStopNode.Name = "txtStopNode";
            this.txtStopNode.Size = new System.Drawing.Size(457, 20);
            this.txtStopNode.TabIndex = 61;
            // 
            // lblStopNode
            // 
            this.lblStopNode.AutoSize = true;
            this.lblStopNode.Location = new System.Drawing.Point(22, 342);
            this.lblStopNode.Name = "lblStopNode";
            this.lblStopNode.Size = new System.Drawing.Size(158, 13);
            this.lblStopNode.TabIndex = 60;
            this.lblStopNode.Text = "Stop-Node Correspondence File";
            // 
            // btnBrowseIntNode
            // 
            this.btnBrowseIntNode.Enabled = false;
            this.btnBrowseIntNode.Location = new System.Drawing.Point(696, 312);
            this.btnBrowseIntNode.Name = "btnBrowseIntNode";
            this.btnBrowseIntNode.Size = new System.Drawing.Size(60, 20);
            this.btnBrowseIntNode.TabIndex = 59;
            this.btnBrowseIntNode.Text = "Browse";
            this.btnBrowseIntNode.UseVisualStyleBackColor = true;
            this.btnBrowseIntNode.Click += new System.EventHandler(this.btnBrowseIntNode_Click);
            // 
            // txtIntNode
            // 
            this.txtIntNode.Enabled = false;
            this.txtIntNode.Location = new System.Drawing.Point(227, 311);
            this.txtIntNode.Name = "txtIntNode";
            this.txtIntNode.Size = new System.Drawing.Size(457, 20);
            this.txtIntNode.TabIndex = 58;
            // 
            // lblIntNode
            // 
            this.lblIntNode.AutoSize = true;
            this.lblIntNode.Location = new System.Drawing.Point(22, 316);
            this.lblIntNode.Name = "lblIntNode";
            this.lblIntNode.Size = new System.Drawing.Size(191, 13);
            this.lblIntNode.TabIndex = 57;
            this.lblIntNode.Text = "Intersection-Node Correspondence File";
            // 
            // btnBrowseExtNode
            // 
            this.btnBrowseExtNode.Enabled = false;
            this.btnBrowseExtNode.Location = new System.Drawing.Point(696, 255);
            this.btnBrowseExtNode.Name = "btnBrowseExtNode";
            this.btnBrowseExtNode.Size = new System.Drawing.Size(60, 20);
            this.btnBrowseExtNode.TabIndex = 56;
            this.btnBrowseExtNode.Text = "Browse";
            this.btnBrowseExtNode.UseVisualStyleBackColor = true;
            this.btnBrowseExtNode.Click += new System.EventHandler(this.btnBrowseExtNode_Click);
            // 
            // txtExtNode
            // 
            this.txtExtNode.Enabled = false;
            this.txtExtNode.Location = new System.Drawing.Point(226, 256);
            this.txtExtNode.Name = "txtExtNode";
            this.txtExtNode.Size = new System.Drawing.Size(457, 20);
            this.txtExtNode.TabIndex = 55;
            // 
            // lblExtNode
            // 
            this.lblExtNode.AutoSize = true;
            this.lblExtNode.Location = new System.Drawing.Point(22, 259);
            this.lblExtNode.Name = "lblExtNode";
            this.lblExtNode.Size = new System.Drawing.Size(100, 13);
            this.lblExtNode.TabIndex = 54;
            this.lblExtNode.Text = "Extended Node File";
            // 
            // btnBrowseParcelNode
            // 
            this.btnBrowseParcelNode.Enabled = false;
            this.btnBrowseParcelNode.Location = new System.Drawing.Point(696, 285);
            this.btnBrowseParcelNode.Name = "btnBrowseParcelNode";
            this.btnBrowseParcelNode.Size = new System.Drawing.Size(60, 20);
            this.btnBrowseParcelNode.TabIndex = 53;
            this.btnBrowseParcelNode.Text = "Browse";
            this.btnBrowseParcelNode.UseVisualStyleBackColor = true;
            this.btnBrowseParcelNode.Click += new System.EventHandler(this.btnBrowseParcelNode_Click);
            // 
            // txtParcelNode
            // 
            this.txtParcelNode.Enabled = false;
            this.txtParcelNode.Location = new System.Drawing.Point(226, 282);
            this.txtParcelNode.Name = "txtParcelNode";
            this.txtParcelNode.Size = new System.Drawing.Size(457, 20);
            this.txtParcelNode.TabIndex = 52;
            // 
            // lblParcelNode
            // 
            this.lblParcelNode.AutoSize = true;
            this.lblParcelNode.Location = new System.Drawing.Point(22, 289);
            this.lblParcelNode.Name = "lblParcelNode";
            this.lblParcelNode.Size = new System.Drawing.Size(166, 13);
            this.lblParcelNode.TabIndex = 51;
            this.lblParcelNode.Text = "Parcel-Node Correspondence File";
            // 
            // lblBufferType
            // 
            this.lblBufferType.AutoSize = true;
            this.lblBufferType.Location = new System.Drawing.Point(23, 425);
            this.lblBufferType.Name = "lblBufferType";
            this.lblBufferType.Size = new System.Drawing.Size(62, 13);
            this.lblBufferType.TabIndex = 50;
            this.lblBufferType.Text = "Buffer Type";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdbBuffTypExp);
            this.panel1.Controls.Add(this.rdbBuffTypLog);
            this.panel1.Controls.Add(this.rdbBuffTypFlat);
            this.panel1.Location = new System.Drawing.Point(165, 413);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(296, 33);
            this.panel1.TabIndex = 49;
            // 
            // rdbBuffTypExp
            // 
            this.rdbBuffTypExp.AutoSize = true;
            this.rdbBuffTypExp.Location = new System.Drawing.Point(181, 7);
            this.rdbBuffTypExp.Name = "rdbBuffTypExp";
            this.rdbBuffTypExp.Size = new System.Drawing.Size(112, 17);
            this.rdbBuffTypExp.TabIndex = 2;
            this.rdbBuffTypExp.Text = "Exponential decay";
            this.rdbBuffTypExp.UseVisualStyleBackColor = true;
            this.rdbBuffTypExp.CheckedChanged += new System.EventHandler(this.rdbBuffType_CheckedChanged);
            // 
            // rdbBuffTypLog
            // 
            this.rdbBuffTypLog.AutoSize = true;
            this.rdbBuffTypLog.Checked = true;
            this.rdbBuffTypLog.Location = new System.Drawing.Point(71, 7);
            this.rdbBuffTypLog.Name = "rdbBuffTypLog";
            this.rdbBuffTypLog.Size = new System.Drawing.Size(93, 17);
            this.rdbBuffTypLog.TabIndex = 1;
            this.rdbBuffTypLog.TabStop = true;
            this.rdbBuffTypLog.Text = "Logistic decay";
            this.rdbBuffTypLog.UseVisualStyleBackColor = true;
            this.rdbBuffTypLog.CheckedChanged += new System.EventHandler(this.rdbBuffType_CheckedChanged);
            // 
            // rdbBuffTypFlat
            // 
            this.rdbBuffTypFlat.AutoSize = true;
            this.rdbBuffTypFlat.Location = new System.Drawing.Point(14, 8);
            this.rdbBuffTypFlat.Name = "rdbBuffTypFlat";
            this.rdbBuffTypFlat.Size = new System.Drawing.Size(42, 17);
            this.rdbBuffTypFlat.TabIndex = 0;
            this.rdbBuffTypFlat.Text = "Flat";
            this.rdbBuffTypFlat.UseVisualStyleBackColor = true;
            this.rdbBuffTypFlat.CheckedChanged += new System.EventHandler(this.rdbBuffType_CheckedChanged);
            // 
            // lblDistCalc
            // 
            this.lblDistCalc.AutoSize = true;
            this.lblDistCalc.Location = new System.Drawing.Point(22, 25);
            this.lblDistCalc.Name = "lblDistCalc";
            this.lblDistCalc.Size = new System.Drawing.Size(98, 13);
            this.lblDistCalc.TabIndex = 48;
            this.lblDistCalc.Text = "Distance Calulation";
            // 
            // rdbNode
            // 
            this.rdbNode.AutoSize = true;
            this.rdbNode.Location = new System.Drawing.Point(330, 25);
            this.rdbNode.Name = "rdbNode";
            this.rdbNode.Size = new System.Drawing.Size(92, 17);
            this.rdbNode.TabIndex = 47;
            this.rdbNode.Text = "Node-to-Node";
            this.rdbNode.UseVisualStyleBackColor = true;
            this.rdbNode.CheckedChanged += new System.EventHandler(this.rdbDistType_CheckedChanged);
            // 
            // rdbCircuity
            // 
            this.rdbCircuity.AutoSize = true;
            this.rdbCircuity.Location = new System.Drawing.Point(253, 25);
            this.rdbCircuity.Name = "rdbCircuity";
            this.rdbCircuity.Size = new System.Drawing.Size(59, 17);
            this.rdbCircuity.TabIndex = 46;
            this.rdbCircuity.Text = "Circuity";
            this.rdbCircuity.UseVisualStyleBackColor = true;
            this.rdbCircuity.CheckedChanged += new System.EventHandler(this.rdbDistType_CheckedChanged);
            // 
            // rdbEuclidean
            // 
            this.rdbEuclidean.AutoSize = true;
            this.rdbEuclidean.Checked = true;
            this.rdbEuclidean.Location = new System.Drawing.Point(165, 25);
            this.rdbEuclidean.Name = "rdbEuclidean";
            this.rdbEuclidean.Size = new System.Drawing.Size(72, 17);
            this.rdbEuclidean.TabIndex = 45;
            this.rdbEuclidean.TabStop = true;
            this.rdbEuclidean.Text = "Euclidean";
            this.rdbEuclidean.UseVisualStyleBackColor = true;
            this.rdbEuclidean.CheckedChanged += new System.EventHandler(this.rdbDistType_CheckedChanged);
            // 
            // txtBuffOffset2
            // 
            this.txtBuffOffset2.Location = new System.Drawing.Point(647, 512);
            this.txtBuffOffset2.Name = "txtBuffOffset2";
            this.txtBuffOffset2.Size = new System.Drawing.Size(57, 20);
            this.txtBuffOffset2.TabIndex = 44;
            this.txtBuffOffset2.Text = "2640.0";
            this.txtBuffOffset2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBuffOffset2
            // 
            this.lblBuffOffset2.AutoSize = true;
            this.lblBuffOffset2.Location = new System.Drawing.Point(453, 518);
            this.lblBuffOffset2.Name = "lblBuffOffset2";
            this.lblBuffOffset2.Size = new System.Drawing.Size(75, 13);
            this.lblBuffOffset2.TabIndex = 43;
            this.lblBuffOffset2.Text = "Buffer 2 Offset";
            // 
            // txtBuffExp2
            // 
            this.txtBuffExp2.Enabled = false;
            this.txtBuffExp2.Location = new System.Drawing.Point(647, 537);
            this.txtBuffExp2.Name = "txtBuffExp2";
            this.txtBuffExp2.Size = new System.Drawing.Size(57, 20);
            this.txtBuffExp2.TabIndex = 42;
            this.txtBuffExp2.Text = "-0.4365";
            this.txtBuffExp2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBuffExp2
            // 
            this.lblBuffExp2.AutoSize = true;
            this.lblBuffExp2.Location = new System.Drawing.Point(453, 544);
            this.lblBuffExp2.Name = "lblBuffExp2";
            this.lblBuffExp2.Size = new System.Drawing.Size(187, 13);
            this.lblBuffExp2.TabIndex = 41;
            this.lblBuffExp2.Text = "Buffer 2 Exponential Decay Parameter";
            // 
            // txtBuffDecay2
            // 
            this.txtBuffDecay2.Location = new System.Drawing.Point(647, 485);
            this.txtBuffDecay2.Name = "txtBuffDecay2";
            this.txtBuffDecay2.Size = new System.Drawing.Size(57, 20);
            this.txtBuffDecay2.TabIndex = 40;
            this.txtBuffDecay2.Text = "0.76";
            this.txtBuffDecay2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBuffDecay2
            // 
            this.lblBuffDecay2.AutoSize = true;
            this.lblBuffDecay2.Location = new System.Drawing.Point(453, 492);
            this.lblBuffDecay2.Name = "lblBuffDecay2";
            this.lblBuffDecay2.Size = new System.Drawing.Size(108, 13);
            this.lblBuffDecay2.TabIndex = 39;
            this.lblBuffDecay2.Text = "Buffer 2 Decay Slope";
            // 
            // txtBuffDist2
            // 
            this.txtBuffDist2.Location = new System.Drawing.Point(647, 460);
            this.txtBuffDist2.Name = "txtBuffDist2";
            this.txtBuffDist2.Size = new System.Drawing.Size(57, 20);
            this.txtBuffDist2.TabIndex = 38;
            this.txtBuffDist2.Text = "1320.0";
            this.txtBuffDist2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBuffDist2
            // 
            this.lblBuffDist2.AutoSize = true;
            this.lblBuffDist2.Location = new System.Drawing.Point(453, 467);
            this.lblBuffDist2.Name = "lblBuffDist2";
            this.lblBuffDist2.Size = new System.Drawing.Size(104, 13);
            this.lblBuffDist2.TabIndex = 37;
            this.lblBuffDist2.Text = "Buffer 2 Distance (ft)";
            // 
            // txtBuffOffset1
            // 
            this.txtBuffOffset1.Location = new System.Drawing.Point(217, 511);
            this.txtBuffOffset1.Name = "txtBuffOffset1";
            this.txtBuffOffset1.Size = new System.Drawing.Size(57, 20);
            this.txtBuffOffset1.TabIndex = 34;
            this.txtBuffOffset1.Text = "2640.0";
            this.txtBuffOffset1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBuffOffset1
            // 
            this.lblBuffOffset1.AutoSize = true;
            this.lblBuffOffset1.Location = new System.Drawing.Point(23, 518);
            this.lblBuffOffset1.Name = "lblBuffOffset1";
            this.lblBuffOffset1.Size = new System.Drawing.Size(75, 13);
            this.lblBuffOffset1.TabIndex = 33;
            this.lblBuffOffset1.Text = "Buffer 1 Offset";
            // 
            // txtBuffExp1
            // 
            this.txtBuffExp1.Enabled = false;
            this.txtBuffExp1.Location = new System.Drawing.Point(217, 537);
            this.txtBuffExp1.Name = "txtBuffExp1";
            this.txtBuffExp1.Size = new System.Drawing.Size(57, 20);
            this.txtBuffExp1.TabIndex = 32;
            this.txtBuffExp1.Text = "-2.5205";
            this.txtBuffExp1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBuffExp1
            // 
            this.lblBuffExp1.AutoSize = true;
            this.lblBuffExp1.Location = new System.Drawing.Point(23, 540);
            this.lblBuffExp1.Name = "lblBuffExp1";
            this.lblBuffExp1.Size = new System.Drawing.Size(187, 13);
            this.lblBuffExp1.TabIndex = 31;
            this.lblBuffExp1.Text = "Buffer 1 Exponential Decay Parameter";
            // 
            // txtBuffDecay1
            // 
            this.txtBuffDecay1.Location = new System.Drawing.Point(217, 485);
            this.txtBuffDecay1.Name = "txtBuffDecay1";
            this.txtBuffDecay1.Size = new System.Drawing.Size(57, 20);
            this.txtBuffDecay1.TabIndex = 30;
            this.txtBuffDecay1.Text = "0.76";
            this.txtBuffDecay1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBuffDecay1
            // 
            this.lblBuffDecay1.AutoSize = true;
            this.lblBuffDecay1.Location = new System.Drawing.Point(23, 492);
            this.lblBuffDecay1.Name = "lblBuffDecay1";
            this.lblBuffDecay1.Size = new System.Drawing.Size(108, 13);
            this.lblBuffDecay1.TabIndex = 29;
            this.lblBuffDecay1.Text = "Buffer 1 Decay Slope";
            // 
            // txtBuffDist1
            // 
            this.txtBuffDist1.Location = new System.Drawing.Point(217, 460);
            this.txtBuffDist1.Name = "txtBuffDist1";
            this.txtBuffDist1.Size = new System.Drawing.Size(57, 20);
            this.txtBuffDist1.TabIndex = 28;
            this.txtBuffDist1.Text = "660.0";
            this.txtBuffDist1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBuffDist1
            // 
            this.lblBuffDist1.AutoSize = true;
            this.lblBuffDist1.Location = new System.Drawing.Point(23, 467);
            this.lblBuffDist1.Name = "lblBuffDist1";
            this.lblBuffDist1.Size = new System.Drawing.Size(104, 13);
            this.lblBuffDist1.TabIndex = 27;
            this.lblBuffDist1.Text = "Buffer 1 Distance (ft)";
            // 
            // btnBrowseNodeDistance
            // 
            this.btnBrowseNodeDistance.Enabled = false;
            this.btnBrowseNodeDistance.Location = new System.Drawing.Point(696, 225);
            this.btnBrowseNodeDistance.Name = "btnBrowseNodeDistance";
            this.btnBrowseNodeDistance.Size = new System.Drawing.Size(60, 20);
            this.btnBrowseNodeDistance.TabIndex = 23;
            this.btnBrowseNodeDistance.Text = "Browse";
            this.btnBrowseNodeDistance.UseVisualStyleBackColor = true;
            this.btnBrowseNodeDistance.Click += new System.EventHandler(this.btnBrowseNodeDistance_Click);
            // 
            // txtNodeDistance
            // 
            this.txtNodeDistance.Enabled = false;
            this.txtNodeDistance.Location = new System.Drawing.Point(226, 226);
            this.txtNodeDistance.Name = "txtNodeDistance";
            this.txtNodeDistance.Size = new System.Drawing.Size(457, 20);
            this.txtNodeDistance.TabIndex = 24;
            // 
            // lblNodeDistance
            // 
            this.lblNodeDistance.AutoSize = true;
            this.lblNodeDistance.Location = new System.Drawing.Point(22, 229);
            this.lblNodeDistance.Name = "lblNodeDistance";
            this.lblNodeDistance.Size = new System.Drawing.Size(138, 13);
            this.lblNodeDistance.TabIndex = 22;
            this.lblNodeDistance.Text = "Node to Node Distance File";
            // 
            // btnBrowseNodeData
            // 
            this.btnBrowseNodeData.Enabled = false;
            this.btnBrowseNodeData.Location = new System.Drawing.Point(696, 200);
            this.btnBrowseNodeData.Name = "btnBrowseNodeData";
            this.btnBrowseNodeData.Size = new System.Drawing.Size(60, 20);
            this.btnBrowseNodeData.TabIndex = 20;
            this.btnBrowseNodeData.Text = "Browse";
            this.btnBrowseNodeData.UseVisualStyleBackColor = true;
            this.btnBrowseNodeData.Click += new System.EventHandler(this.btnBrowseNodeData_Click);
            // 
            // txtNodeData
            // 
            this.txtNodeData.Enabled = false;
            this.txtNodeData.Location = new System.Drawing.Point(226, 200);
            this.txtNodeData.Name = "txtNodeData";
            this.txtNodeData.Size = new System.Drawing.Size(457, 20);
            this.txtNodeData.TabIndex = 21;
            // 
            // lblNodeData
            // 
            this.lblNodeData.AutoSize = true;
            this.lblNodeData.Location = new System.Drawing.Point(22, 203);
            this.lblNodeData.Name = "lblNodeData";
            this.lblNodeData.Size = new System.Drawing.Size(78, 13);
            this.lblNodeData.TabIndex = 19;
            this.lblNodeData.Text = "Node Data File";
            // 
            // btnBrowseCircuity
            // 
            this.btnBrowseCircuity.Enabled = false;
            this.btnBrowseCircuity.Location = new System.Drawing.Point(696, 173);
            this.btnBrowseCircuity.Name = "btnBrowseCircuity";
            this.btnBrowseCircuity.Size = new System.Drawing.Size(60, 20);
            this.btnBrowseCircuity.TabIndex = 17;
            this.btnBrowseCircuity.Text = "Browse";
            this.btnBrowseCircuity.UseVisualStyleBackColor = true;
            this.btnBrowseCircuity.Click += new System.EventHandler(this.btnBrowseCircuity_Click);
            // 
            // txtCircuity
            // 
            this.txtCircuity.Enabled = false;
            this.txtCircuity.Location = new System.Drawing.Point(226, 169);
            this.txtCircuity.Name = "txtCircuity";
            this.txtCircuity.Size = new System.Drawing.Size(457, 20);
            this.txtCircuity.TabIndex = 18;
            // 
            // lblCircuity
            // 
            this.lblCircuity.AutoSize = true;
            this.lblCircuity.Location = new System.Drawing.Point(22, 177);
            this.lblCircuity.Name = "lblCircuity";
            this.lblCircuity.Size = new System.Drawing.Size(86, 13);
            this.lblCircuity.TabIndex = 16;
            this.lblCircuity.Text = "Circuity Data File";
            // 
            // btnBrowseOpenSpaces
            // 
            this.btnBrowseOpenSpaces.Location = new System.Drawing.Point(696, 142);
            this.btnBrowseOpenSpaces.Name = "btnBrowseOpenSpaces";
            this.btnBrowseOpenSpaces.Size = new System.Drawing.Size(60, 20);
            this.btnBrowseOpenSpaces.TabIndex = 14;
            this.btnBrowseOpenSpaces.Text = "Browse";
            this.btnBrowseOpenSpaces.UseVisualStyleBackColor = true;
            this.btnBrowseOpenSpaces.Click += new System.EventHandler(this.btnBrowseOpenSpaces_Click);
            // 
            // txtOpenSpaces
            // 
            this.txtOpenSpaces.Location = new System.Drawing.Point(226, 143);
            this.txtOpenSpaces.Name = "txtOpenSpaces";
            this.txtOpenSpaces.Size = new System.Drawing.Size(457, 20);
            this.txtOpenSpaces.TabIndex = 15;
            // 
            // lblOpenSpaces
            // 
            this.lblOpenSpaces.AutoSize = true;
            this.lblOpenSpaces.Location = new System.Drawing.Point(22, 150);
            this.lblOpenSpaces.Name = "lblOpenSpaces";
            this.lblOpenSpaces.Size = new System.Drawing.Size(91, 13);
            this.lblOpenSpaces.TabIndex = 13;
            this.lblOpenSpaces.Text = "Open Spaces File";
            // 
            // btnBrowseTransitStops
            // 
            this.btnBrowseTransitStops.Location = new System.Drawing.Point(696, 112);
            this.btnBrowseTransitStops.Name = "btnBrowseTransitStops";
            this.btnBrowseTransitStops.Size = new System.Drawing.Size(60, 20);
            this.btnBrowseTransitStops.TabIndex = 11;
            this.btnBrowseTransitStops.Text = "Browse";
            this.btnBrowseTransitStops.UseVisualStyleBackColor = true;
            this.btnBrowseTransitStops.Click += new System.EventHandler(this.btnBrowseTransitStops_Click);
            // 
            // txtTransitStops
            // 
            this.txtTransitStops.Location = new System.Drawing.Point(226, 113);
            this.txtTransitStops.Name = "txtTransitStops";
            this.txtTransitStops.Size = new System.Drawing.Size(457, 20);
            this.txtTransitStops.TabIndex = 12;
            this.txtTransitStops.TextChanged += new System.EventHandler(this.txtTransitStops_TextChanged);
            // 
            // lblTransitStops
            // 
            this.lblTransitStops.AutoSize = true;
            this.lblTransitStops.Location = new System.Drawing.Point(22, 120);
            this.lblTransitStops.Name = "lblTransitStops";
            this.lblTransitStops.Size = new System.Drawing.Size(88, 13);
            this.lblTransitStops.TabIndex = 10;
            this.lblTransitStops.Text = "Transit Stops File";
            // 
            // btnBrowseIntersection
            // 
            this.btnBrowseIntersection.Location = new System.Drawing.Point(696, 84);
            this.btnBrowseIntersection.Name = "btnBrowseIntersection";
            this.btnBrowseIntersection.Size = new System.Drawing.Size(60, 20);
            this.btnBrowseIntersection.TabIndex = 8;
            this.btnBrowseIntersection.Text = "Browse";
            this.btnBrowseIntersection.UseVisualStyleBackColor = true;
            this.btnBrowseIntersection.Click += new System.EventHandler(this.btnBrowseIntersection_Click);
            // 
            // txtIntersection
            // 
            this.txtIntersection.Location = new System.Drawing.Point(226, 83);
            this.txtIntersection.Name = "txtIntersection";
            this.txtIntersection.Size = new System.Drawing.Size(457, 20);
            this.txtIntersection.TabIndex = 9;
            // 
            // lblIntersection
            // 
            this.lblIntersection.AutoSize = true;
            this.lblIntersection.Location = new System.Drawing.Point(22, 88);
            this.lblIntersection.Name = "lblIntersection";
            this.lblIntersection.Size = new System.Drawing.Size(107, 13);
            this.lblIntersection.TabIndex = 7;
            this.lblIntersection.Text = "Intersection Data File";
            // 
            // btnBrowseParcelData
            // 
            this.btnBrowseParcelData.Location = new System.Drawing.Point(696, 57);
            this.btnBrowseParcelData.Name = "btnBrowseParcelData";
            this.btnBrowseParcelData.Size = new System.Drawing.Size(60, 20);
            this.btnBrowseParcelData.TabIndex = 6;
            this.btnBrowseParcelData.Text = "Browse";
            this.btnBrowseParcelData.UseVisualStyleBackColor = true;
            this.btnBrowseParcelData.Click += new System.EventHandler(this.btnBrowseParcelData_Click);
            // 
            // txtParcelData
            // 
            this.txtParcelData.Location = new System.Drawing.Point(226, 58);
            this.txtParcelData.Name = "txtParcelData";
            this.txtParcelData.Size = new System.Drawing.Size(457, 20);
            this.txtParcelData.TabIndex = 6;
            // 
            // lblParcelData
            // 
            this.lblParcelData.AutoSize = true;
            this.lblParcelData.Location = new System.Drawing.Point(22, 57);
            this.lblParcelData.Name = "lblParcelData";
            this.lblParcelData.Size = new System.Drawing.Size(82, 13);
            this.lblParcelData.TabIndex = 0;
            this.lblParcelData.Text = "Parcel Data File";
            // 
            // gbReadXML
            // 
            this.gbReadXML.Controls.Add(this.btnBrowseXMLInput);
            this.gbReadXML.Controls.Add(this.txtXMLInput);
            this.gbReadXML.Controls.Add(this.lblXMLInput);
            this.gbReadXML.Location = new System.Drawing.Point(12, 12);
            this.gbReadXML.Name = "gbReadXML";
            this.gbReadXML.Size = new System.Drawing.Size(762, 63);
            this.gbReadXML.TabIndex = 5;
            this.gbReadXML.TabStop = false;
            this.gbReadXML.Text = "Read XML Input";
            // 
            // btnBrowseXMLInput
            // 
            this.btnBrowseXMLInput.Location = new System.Drawing.Point(696, 26);
            this.btnBrowseXMLInput.Name = "btnBrowseXMLInput";
            this.btnBrowseXMLInput.Size = new System.Drawing.Size(60, 20);
            this.btnBrowseXMLInput.TabIndex = 4;
            this.btnBrowseXMLInput.Text = "Browse";
            this.btnBrowseXMLInput.UseVisualStyleBackColor = true;
            this.btnBrowseXMLInput.Click += new System.EventHandler(this.btnBrowseXML_Click);
            // 
            // gbOutputs
            // 
            this.gbOutputs.Controls.Add(this.btnBrowseXMLOutput);
            this.gbOutputs.Controls.Add(this.txtXMLOutput);
            this.gbOutputs.Controls.Add(this.lblXMLOutput);
            this.gbOutputs.Controls.Add(this.btnBrowseOutputParcel);
            this.gbOutputs.Controls.Add(this.txtOutputParcel);
            this.gbOutputs.Controls.Add(this.lblOutputParcel);
            this.gbOutputs.Location = new System.Drawing.Point(12, 642);
            this.gbOutputs.Name = "gbOutputs";
            this.gbOutputs.Size = new System.Drawing.Size(762, 73);
            this.gbOutputs.TabIndex = 6;
            this.gbOutputs.TabStop = false;
            this.gbOutputs.Text = "OUTPUT";
            // 
            // btnBrowseXMLOutput
            // 
            this.btnBrowseXMLOutput.Location = new System.Drawing.Point(696, 42);
            this.btnBrowseXMLOutput.Name = "btnBrowseXMLOutput";
            this.btnBrowseXMLOutput.Size = new System.Drawing.Size(59, 19);
            this.btnBrowseXMLOutput.TabIndex = 5;
            this.btnBrowseXMLOutput.Text = "Browse";
            this.btnBrowseXMLOutput.UseVisualStyleBackColor = true;
            this.btnBrowseXMLOutput.Click += new System.EventHandler(this.btnBrowseXMLOutput_Click);
            // 
            // txtXMLOutput
            // 
            this.txtXMLOutput.Location = new System.Drawing.Point(226, 42);
            this.txtXMLOutput.Name = "txtXMLOutput";
            this.txtXMLOutput.Size = new System.Drawing.Size(457, 20);
            this.txtXMLOutput.TabIndex = 4;
            // 
            // lblXMLOutput
            // 
            this.lblXMLOutput.AutoSize = true;
            this.lblXMLOutput.Location = new System.Drawing.Point(23, 49);
            this.lblXMLOutput.Name = "lblXMLOutput";
            this.lblXMLOutput.Size = new System.Drawing.Size(126, 13);
            this.lblXMLOutput.TabIndex = 3;
            this.lblXMLOutput.Text = "Output XML file (optional)";
            // 
            // btnBrowseOutputParcel
            // 
            this.btnBrowseOutputParcel.Location = new System.Drawing.Point(696, 16);
            this.btnBrowseOutputParcel.Name = "btnBrowseOutputParcel";
            this.btnBrowseOutputParcel.Size = new System.Drawing.Size(59, 19);
            this.btnBrowseOutputParcel.TabIndex = 2;
            this.btnBrowseOutputParcel.Text = "Browse";
            this.btnBrowseOutputParcel.UseVisualStyleBackColor = true;
            this.btnBrowseOutputParcel.Click += new System.EventHandler(this.btnBrowseOutput_Click);
            // 
            // txtOutputParcel
            // 
            this.txtOutputParcel.Location = new System.Drawing.Point(226, 15);
            this.txtOutputParcel.Name = "txtOutputParcel";
            this.txtOutputParcel.Size = new System.Drawing.Size(457, 20);
            this.txtOutputParcel.TabIndex = 1;
            // 
            // lblOutputParcel
            // 
            this.lblOutputParcel.AutoSize = true;
            this.lblOutputParcel.Location = new System.Drawing.Point(23, 22);
            this.lblOutputParcel.Name = "lblOutputParcel";
            this.lblOutputParcel.Size = new System.Drawing.Size(101, 13);
            this.lblOutputParcel.TabIndex = 0;
            this.lblOutputParcel.Text = "Buffered Output File";
            // 
            // DSBuff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 771);
            this.Controls.Add(this.gbOutputs);
            this.Controls.Add(this.gbReadXML);
            this.Controls.Add(this.gbInputs);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRun);
            this.Name = "DSBuff";
            this.Text = "DaySim Buffering Tool";
            this.gbInputs.ResumeLayout(false);
            this.gbInputs.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbReadXML.ResumeLayout(false);
            this.gbReadXML.PerformLayout();
            this.gbOutputs.ResumeLayout(false);
            this.gbOutputs.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblXMLInput;
        private System.Windows.Forms.TextBox txtXMLInput;
        private System.Windows.Forms.GroupBox gbInputs;
        private System.Windows.Forms.GroupBox gbReadXML;
        private System.Windows.Forms.Button btnBrowseXMLInput;
        private System.Windows.Forms.TextBox txtBuffOffset2;
        private System.Windows.Forms.Label lblBuffOffset2;
        private System.Windows.Forms.TextBox txtBuffExp2;
        private System.Windows.Forms.Label lblBuffExp2;
        private System.Windows.Forms.TextBox txtBuffDecay2;
        private System.Windows.Forms.Label lblBuffDecay2;
        private System.Windows.Forms.TextBox txtBuffDist2;
        private System.Windows.Forms.Label lblBuffDist2;
        private System.Windows.Forms.TextBox txtBuffOffset1;
        private System.Windows.Forms.Label lblBuffOffset1;
        private System.Windows.Forms.TextBox txtBuffExp1;
        private System.Windows.Forms.Label lblBuffExp1;
        private System.Windows.Forms.TextBox txtBuffDecay1;
        private System.Windows.Forms.Label lblBuffDecay1;
        private System.Windows.Forms.TextBox txtBuffDist1;
        private System.Windows.Forms.Label lblBuffDist1;
        private System.Windows.Forms.Button btnBrowseNodeDistance;
        private System.Windows.Forms.TextBox txtNodeDistance;
        private System.Windows.Forms.Label lblNodeDistance;
        private System.Windows.Forms.Button btnBrowseNodeData;
        private System.Windows.Forms.TextBox txtNodeData;
        private System.Windows.Forms.Label lblNodeData;
        private System.Windows.Forms.Button btnBrowseCircuity;
        private System.Windows.Forms.TextBox txtCircuity;
        private System.Windows.Forms.Label lblCircuity;
        private System.Windows.Forms.Button btnBrowseOpenSpaces;
        private System.Windows.Forms.TextBox txtOpenSpaces;
        private System.Windows.Forms.Label lblOpenSpaces;
        private System.Windows.Forms.Button btnBrowseTransitStops;
        private System.Windows.Forms.TextBox txtTransitStops;
        private System.Windows.Forms.Label lblTransitStops;
        private System.Windows.Forms.Button btnBrowseIntersection;
        private System.Windows.Forms.TextBox txtIntersection;
        private System.Windows.Forms.Label lblIntersection;
        private System.Windows.Forms.Button btnBrowseParcelData;
        private System.Windows.Forms.TextBox txtParcelData;
        private System.Windows.Forms.Label lblParcelData;
        private System.Windows.Forms.GroupBox gbOutputs;
        private System.Windows.Forms.Button btnBrowseOutputParcel;
        private System.Windows.Forms.TextBox txtOutputParcel;
        private System.Windows.Forms.Label lblOutputParcel;
        private System.Windows.Forms.RadioButton rdbNode;
        private System.Windows.Forms.RadioButton rdbCircuity;
        private System.Windows.Forms.RadioButton rdbEuclidean;
        private System.Windows.Forms.Label lblDistCalc;
        private System.Windows.Forms.TextBox txtXMLOutput;
        private System.Windows.Forms.Label lblXMLOutput;
        private System.Windows.Forms.Button btnBrowseXMLOutput;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblBufferType;
        private System.Windows.Forms.RadioButton rdbBuffTypExp;
        private System.Windows.Forms.RadioButton rdbBuffTypLog;
        private System.Windows.Forms.RadioButton rdbBuffTypFlat;
        private System.Windows.Forms.Button btnBrowseExtNode;
        private System.Windows.Forms.TextBox txtExtNode;
        private System.Windows.Forms.Label lblExtNode;
        private System.Windows.Forms.Button btnBrowseParcelNode;
        private System.Windows.Forms.TextBox txtParcelNode;
        private System.Windows.Forms.Label lblParcelNode;
        private System.Windows.Forms.Button btnBrowseOpenSpacesNode;
        private System.Windows.Forms.TextBox txtOpenSpacesNode;
        private System.Windows.Forms.Label lblOpenSpacesNode;
        private System.Windows.Forms.Button btnBrowseStopNode;
        private System.Windows.Forms.TextBox txtStopNode;
        private System.Windows.Forms.Label lblStopNode;
        private System.Windows.Forms.Button btnBrowseIntNode;
        private System.Windows.Forms.TextBox txtIntNode;
        private System.Windows.Forms.Label lblIntNode;
    }
}

