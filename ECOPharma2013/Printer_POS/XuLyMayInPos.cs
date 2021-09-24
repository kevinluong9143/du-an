using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ECOPharma2013.SQL;
using ECOPharma2013.DuLieu;
using ECOPharma2013.Printer_POS;
using System.Drawing.Printing;
using System.IO;
using Microsoft.PointOfService;
using System.Text.RegularExpressions;

namespace ECOPharma2013.Printer_POS
{
    class XuLyMayInPos
    {
        public string CatBoBot(string text, int maxWidth)
        {
            string retVal = text;
            if (text.Length > maxWidth)
                retVal = text.Substring(0, maxWidth);
            return retVal;
        }
        public string InCanhGiua(string chuoi)
        {
            string t = System.Text.ASCIIEncoding.ASCII.GetString(new byte[] { 27, (byte)'|', (byte)'c', (byte)'A' }) + chuoi;
            return t;
        }
        public string InCanhPhai(string chuoi)
        {
            string t = System.Text.ASCIIEncoding.ASCII.GetString(new byte[] { 27, (byte)'|', (byte)'r', (byte)'A' }) + chuoi;
            return t;
        }
        public string CatGiay()
        {
            string t = System.Text.ASCIIEncoding.ASCII.GetString(new byte[] { 27, (byte)'|', (byte)'9', (byte)'0', (byte)'P' });
            return t;
        }
        public string ConvertToUnSign(string text)
        {
            for (int i = 33; i < 48; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }

            for (int i = 58; i < 65; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }

            for (int i = 91; i < 97; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }
            for (int i = 123; i < 127; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }
            //text = text.Replace(" ", "-");
            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string strFormD = text.Normalize(System.Text.NormalizationForm.FormD);
            return regex.Replace(strFormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

        #region An
        private PrinterStation CurrentStation;
        private PosExplorer posExplorer;
        private TreeNode posPrinter;
        private PosCommon _posCommon;
        public PosDeviceTag currentDevice = null;
        public PosPrinter _printer;

        public XuLyMayInPos() { }
        public XuLyMayInPos(Form aFrom, ToolStripStatusLabel statusTB)
        {
            CurrentStation = PrinterStation.Receipt;
            posExplorer = new PosExplorer(aFrom);
            posExplorer.DeviceAddedEvent += new DeviceChangedEventHandler(root_OnDeviceAdded);
            posExplorer.DeviceRemovedEvent += new DeviceChangedEventHandler(root_OnDeviceRemoved);
            RefreshDeviceTree(false);
            Open(statusTB);
        }
        private void root_OnDeviceAdded(object sender, DeviceChangedEventArgs e)
        {
            RefreshDeviceTree(true);
        }
        private void root_OnDeviceRemoved(object source, DeviceChangedEventArgs e)
        {
            RefreshDeviceTree(false);
        }
        private void RefreshDeviceTree(bool showAddedDevice)
        {
            try
            {
                DeviceCollection devices = posExplorer.GetDevices((DeviceCompatibilities)Enum.Parse(typeof(DeviceCompatibilities), "OposAndCompatibilityLevel1", false));
                try
                {
                    AddDevicesToTree(devices, showAddedDevice);
                }
                catch (Exception ae)
                {
                    ShowException(ae);
                }
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }
        internal void ShowException(Exception e)
        {
            Exception inner = e.InnerException;
            if (inner != null)
            {
                ShowException(inner);
            }

            if (e is PosControlException)
            {
                PosControlException pe = (PosControlException)e;

                MessageBox.Show("POSControlException ErrorCode(" + pe.ErrorCode.ToString() + ") ExtendedErrorCode(" + pe.ErrorCodeExtended.ToString() + ") occurred: " + pe.Message);
            }
            else
            {
                MessageBox.Show(e.ToString());
            }
        }
        private void AddDevicesToTree(DeviceCollection devices, bool showAddedDevice)
        {
            foreach (DeviceInfo device in devices)
            {
                TreeNode deviceNode = null;
                if (deviceNode == null)
                {
                    TreeNode DeviceNode = new TreeNode(GetDeviceDisplayName(device));
                    DeviceNode.Tag = new PosDeviceTag(device);

                    if (GetDeviceDisplayName(device).Equals("PosPrinter"))
                    {
                        posPrinter = DeviceNode;
                        break;
                    }
                }
            }
        }
        static string GetDeviceDisplayName(DeviceInfo device)
        {
            string name = CombineNames(device.LogicalNames);
            if (name.Length == 0)
            {
                name = device.ServiceObjectName;
                if (name.Length == 0)
                    name = device.Description;
            }
            return name;
        }
        public void Open(ToolStripStatusLabel statusTB)
        {
            try
            {
                OpenDevice(posPrinter, statusTB);
            }
            catch (Exception ae)
            {
                ShowException(ae);
            }
        }
        private void OpenDevice(TreeNode node, ToolStripStatusLabel statusTB)
        {
            if (node == null || node.Tag == null)
            {
                statusTB.Text = "Thiết bị không khả dụng";
                return;
            }
            else
            {
                statusTB.Text = "Thiết bị khả dụng";
            }

            PosDeviceTag tag = (PosDeviceTag)node.Tag;

            if (tag == null)
            {
                statusTB.Text = "Thiết bị không khả dụng";
                return;
            }
            else
            {
                statusTB.Text = "Thiết bị khả dụng";
            }

            try
            {
                DeviceInfo device = tag.DeviceInfo;

                if (tag.posCommon == null)
                {
                    tag.posCommon = (PosCommon)posExplorer.CreateInstance(device);
                }
                else
                {
                    MessageBox.Show("Using existing instance of device: " + device.ServiceObjectName);
                }

                tag.posCommon.Open();
                ShowDeviceScreen(tag);
            }
            catch (Exception ae)
            {
                tag.posCommon = null;
                ShowException(ae);
            }
        }
        private void ShowDeviceScreen(PosDeviceTag tag)
        {
            if (tag != null && tag.posCommon != null)
            {
                _posCommon = tag.posCommon;
                currentDevice = tag;
            }
        }
        static string CombineNames(string[] names)
        {
            string s = "";
            foreach (string name in names)
            {
                if (s.Length > 0)
                    s += ';';
                s += name;
            }

            return s;
        }
        public PosDeviceTag EnableThietBi()
        {
            PosDeviceTag tag = currentDevice;
            if (tag == null)
                return tag;

            try
            {
                tag.posCommon.Claim(1000);
                //Enable Thiet Bi
                PosCommon pc = tag.posCommon;
                try
                {
                    pc.DeviceEnabled = true;
                }
                catch (Exception ae)
                {
                    ShowException(ae);
                }
            }
            catch
            {

            }
            return tag;
        }
        public int CreateRecLineChars()
        {
            _printer = (PosPrinter)_posCommon;
            return _printer.RecLineChars;
        }
        public void InChinhSua(string text)
        {
            //Goi ham Print
            _printer = (PosPrinter)_posCommon;
            if (text.Length < _printer.RecLineChars)
                _printer.PrintNormal(PrinterStation.Receipt, text + Environment.NewLine); //Print text, then a new line character.
            else if (text.Length > _printer.RecLineChars)
                _printer.PrintNormal(PrinterStation.Receipt, CatBoBot(text, _printer.RecLineChars)); //Print exactly as many characters as the printer allows, truncating the rest, no new line character (printer will probably auto-feed for us)
            else if (text.Length == _printer.RecLineChars)
                _printer.PrintNormal(PrinterStation.Receipt, text + Environment.NewLine); //Print text, no new line character, printer will probably auto-feed for us.
        }
        public void InBinhThuong(string text)
        {
            _printer = (PosPrinter)_posCommon;

            if (text.Length <= _printer.RecLineChars)
                _printer.PrintNormal(PrinterStation.Receipt, text); //Print text
            else if (text.Length > _printer.RecLineChars)
                _printer.PrintNormal(PrinterStation.Receipt, CatBoBot(text, _printer.RecLineChars)); //Print exactly as many characters as the printer allows, truncating the rest.
        }
        public string InDam_ChinhSize_CanhGiua(string chuoi)
        {
            string t = System.Text.ASCIIEncoding.ASCII.GetString(new byte[] { 27, (byte)'|', (byte)'c', (byte)'A', 27, (byte)'|', (byte)'2', (byte)'C' }) + chuoi;
            return t;
        }
        public void Disable(PosDeviceTag tag)
        {
            //Disable Thiet Bi
            tag.posCommon.Release();
        }
        #endregion
    }
    class PosDeviceTag
    {
        public PosDeviceTag(DeviceInfo deviceInfo)
        {
            DeviceInfo = deviceInfo;
        }

        public DeviceInfo DeviceInfo;
        public PosCommon posCommon;
    }
}
