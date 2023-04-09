 // Rename it to index.js for execution to happen.
 import { Observable, catchError } from "rxjs";

 /**
  * Observerable wraps the producers 
  */
 const obs = new Observable((observer) => {
    let counter = 1;
    setInterval(()=>{
        observer.next(counter++);
    }, 1000)
 });

 obs.pipe(catchError(() => {console.log('')})).subscribe((data)=> {console.log(data)});

 function nextMethod(value:any){
   
 }