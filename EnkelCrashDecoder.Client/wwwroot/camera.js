import QrScanner from "./qr-scanner.min.js";

export class QrScannerCamera {

    static init(backend) {
        var backendObject = backend;
        var video = document.getElementById('qr-video');

        const scanner = new QrScanner(video, result => { backendObject.invokeMethodAsync( 'OnScan', result.data); }, {
            onDecodeError: error => {
                backendObject.invokeMethodAsync('OnError',error.data);
            },
            calculateScanRegion: function (video) {
                return {
                    x: 0,
                    y: 0,
                    width: video.videoWidth,
                    height: video.videoHeight
                }
            },
            highlightScanRegion: true,
            highlightCodeOutline: true,
        });

        // for debugging
        window.scanner = scanner;

        scanner.start();

        return {
            start: function(){
                scanner.start();
            },
            stop: function () {
                scanner.stop();
            }
        };
    }
}
