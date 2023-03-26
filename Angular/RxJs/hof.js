
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


// Simple HOF Observable -  
function ObservableHOF(observer){
    let counter = 1;
    // Producer the emits data every 1 sec   
    const producer = setInterval(() => {
        observer.next(counter++);
    }, 1000);

    // Subscription - Cancel / Terminate the Observable
    return () => {
        clearInterval(producer)
    };
}

const subscription = ObservableHOF({
    next : (data) => console.log(data),
    error : (error) => console.log('error '+ error),
    completed : () => console.log('Done'),
});

setInterval(() => {
    subscription();
}, 5000)
