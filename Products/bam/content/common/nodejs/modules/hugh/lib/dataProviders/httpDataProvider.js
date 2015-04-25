var httpDataProvider = (function(){
    var http = require('urllib-sync').create();

    function postTo(url, data){
        http.request(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            content: JSON.stringify(data)
        }, function(err, data, res){
           if(err){
               throw new Error(err);
           }else{

           }
        });
    }

    function getFrom(url, data){

    }

    return {

    }
})();