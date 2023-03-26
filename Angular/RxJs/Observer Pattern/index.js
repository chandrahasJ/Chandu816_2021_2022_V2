// Producer that emits value in every 1 sec
function producer(observer){    
    let counter = 1;
    // Producer 
    const producer  = setInterval( () => {
        observer.next(counter++);
        // if(counter == 6){
        //     observer.error('Scenrio - Error occured')
        // }
    
        // if(counter == 10){
        // Scenrio - Completed.
        //     observer.completed();
        // }
    }, 1000);

    //un-subscription / cancel 
    return () => {
        clearInterval(producer);
    }
}

// Observable - which will be used to wrap the procuder 
class Observable
{
    constructor(blueprint){
        this.observable = blueprint; 
    }

    subsribe(observer){
        const observerWithGuard = new ObserverGuard(observer);
        const closeFn = this.observable(observerWithGuard);
        observerWithGuard.closeFn = closeFn;

        return this.subscriptionMetadata(observerWithGuard);
    }

    subscriptionMetadata(observerWithGuard){
        return {
            unsubscribed(){
                observerWithGuard.unsubscribe();
            },
            get closed(){
                return observerWithGuard.closed();
            }
        }
    }
}

// Wrapper for Observer 
// So that we can check current status of observer
// i.e. it is subscribed or not 
// in case of error or completed, unsubsribe the observer etc.
class ObserverGuard
{
    constructor(observer){
        this.observer = observer;
        this.unSubscribed = false;
    }

    next(data){
        if(this.unSubscribed || !this.observer.next){ 
            this.unsubscribe();          
            return;
        }
        try{
            this.observer.next(data)
        }catch (error){
            this.unsubscribe(); throw error;
        }
    }

    error(err){
        if(this.unSubscribed || !this.observer.error){
            this.unsubscribe();
            return;
        }
        try{
            this.observer.error(err);
        }catch (innerError){
            this.unsubscribe(); throw innerError;
        }
        this.unsubscribe();
    }

    completed(){
        if(this.unSubscribed || !this.observer.completed){
            this.unsubscribe();
            return;
        }
        try{
            this.observer.completed();
        }catch (error){
            this.unsubscribe();  throw error;
        }
        this.unsubscribe();
    }

    unsubscribe(){
        this.unSubscribed = true;        
        if(this.closeFn){
            this.closeFn();
        }
    }

    closed(){
        return this.unSubscribed;
    }
}

const observerableObject = new Observable(producer);

const subscriptionObject = observerableObject.subsribe({
    next : (data) => console.log(data),
    error : (error) => console.log('error '+ error),
    completed : () => console.log('Done'),
});

console.log(subscriptionObject.closed)

setTimeout(() => {
    subscriptionObject.unsubscribed();
    console.log(subscriptionObject.closed)
}, 5000)
