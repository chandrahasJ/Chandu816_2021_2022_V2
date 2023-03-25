
const myFunction = function(name){
    return "My name is "+ name +'.';
};

function hof(name, fn){
    return logMe(fn(name));
}

function logMe(msg){
    console.log(msg);
}

// So this is a Higher order funtion which takes a 
// argument as parameter and returns a function as a
// return value
hof("CJ", myFunction);
// Output : My name is CJ.