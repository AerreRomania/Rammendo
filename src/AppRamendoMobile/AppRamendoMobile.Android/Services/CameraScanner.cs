using System.Threading.Tasks;
using ZXing.Mobile;
using AppRammendoMobile.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(LogicTrade.DeliveryAssist.Droid.Services.QrScannerService))]
namespace LogicTrade.DeliveryAssist.Droid.Services
{
    public class QrScannerService : ICameraScanner
    {
        public async Task<string> ScanAsync() {
            var optionsCustom = new MobileBarcodeScanningOptions();

            var scanner = new MobileBarcodeScanner() {
                UseCustomOverlay = false,
                TopText = "Scanning...",
                BottomText = "Please wait...",
            };

            optionsCustom.PossibleFormats = new System.Collections.Generic.List<ZXing.BarcodeFormat>()
            {
                ZXing.BarcodeFormat.QR_CODE,
                ZXing.BarcodeFormat.CODABAR,
                ZXing.BarcodeFormat.CODE_39,
                ZXing.BarcodeFormat.EAN_13,
                ZXing.BarcodeFormat.EAN_8,
                ZXing.BarcodeFormat.All_1D,
                ZXing.BarcodeFormat.UPC_EAN_EXTENSION,
                ZXing.BarcodeFormat.UPC_E,
                ZXing.BarcodeFormat.UPC_A,
                ZXing.BarcodeFormat.CODE_128,
                ZXing.BarcodeFormat.CODE_93
            };
            var scanResult = await scanner.Scan(optionsCustom);

            return scanResult.Text;
        }
    }
}

