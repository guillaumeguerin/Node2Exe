// Load the http module to create an http server.
var http = require('http'),
	port = process.argv[2] || 8080;

// Configure our HTTP server to respond with Hello World to all requests.
var server = http.createServer(function (request, response) {
  response.writeHead(200, {"Content-Type": "text/plain"});
  response.end("Hello World\n");
});

// Listen on port 8000, IP defaults to 127.0.0.1
server.listen(port);

// Put a friendly message on the terminal
console.log("Server running at http://127.0.0.1:"+ port +"/");

function cmd_exec(cmd, args, cb_stdout, cb_end) {
  var spawn = require('child_process').spawn,
    child = spawn(cmd, args),
    me = this;
  me.exit = 0;  // Send a cb to set 1 when cmd exits
  child.stdout.on('data', function (data) { cb_stdout(me, data) });
  child.stdout.on('end', function () { cb_end(me) });
}
foo = new cmd_exec('Browser.exe', ['http://127.0.0.1:'+ port +'/'], 
  function (me, data) {me.stdout += data.toString();},
  function (me) {me.exit = 1;}
);