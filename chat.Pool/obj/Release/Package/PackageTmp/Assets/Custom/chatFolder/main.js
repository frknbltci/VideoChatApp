let peer = null;

$(document).ready(function () {
    navigator.getUserMedia = navigator.getUserMedia || navigator.webkitGetUserMedia || navigator.mozGetUserMedia;
    window.video = $('#video');
    window.video.hide();
    window.call = null;
    window.receiving = false;
    initPeer();
});

const initPeer = function () {
    peer = new Peer({ host: 'hello-peers.herokuapp.com', port: '' });
    peer.on('open', function (id) {
        $('#info').text('Idle');
        $('#myId').val(id);
    });

    peer.on('call', function (call) {
        $('#info').text('Receiving');
        window.call = call;
        window.receiving = true;
    });
};

const accept = function () {
    if (receiving) {
        answerCall();
    } else {
        makeCall();
    }
};

const reject = function () {
    if (window.call) {
        window.call.close();
        window.call = null;
    }

    window.localStream.getTracks().forEach(track => track.stop());
    window.video.hide();
    $('#info').text('Idle');
};

const makeCall = function () {
    const peerId = $('#peerId').val();

    if (!peerId) {
        alert('Please enter peer id');
        return;
    }

    $('#info').text('Calling...');
    navigator.getUserMedia({ audio: true, video: true }, function (stream) {
        window.localStream = stream;
        window.call = peer.call(peerId, stream);
        call.on('stream', startCall);
        call.on('close', endCall);
    }, function () {
        alert("Error! Make sure to click allow when asked for permission by the browser");
    });
};

const answerCall = function () {
    if (!window.call || !window.receiving) {
        return;
    }

    $('#info').text('Connecting...');
    navigator.getUserMedia({ video: true, audio: true }, function (stream) {
        window.localStream = stream;
        window.call.answer(stream);
        window.call.on('stream', startCall);
        window.call.on('close', endCall);
    }, function () {
        alert("Error! Make sure to click allow when asked for permission by the browser");
    });
};

const startCall = function (remoteStream) {
    window.video.get(0).src = URL.createObjectURL(remoteStream);
    window.video.get(0).play();
    window.video.show();
    $('#info').text('Connected');
};

const endCall = function () {
    window.receiving = false;
    window.localStream.getTracks().forEach(track => track.stop());
    window.video.hide();
    $('#info').text('Idle');
};