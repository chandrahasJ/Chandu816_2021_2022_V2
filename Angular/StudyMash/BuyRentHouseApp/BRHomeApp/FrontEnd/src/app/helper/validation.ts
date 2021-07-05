import { AbstractControl, FormGroup, ValidatorFn } from "@angular/forms";


export default class CustomValidations{
    static match(controlName : string, matchingControlName : string) : ValidatorFn{
        return (controls : AbstractControl) =>{
            const control = controls.get(controlName);
            const matchingControl = controls.get(matchingControlName);
            if(control?.errors && !control.errors.matching){
                return null;
            }
           
            if(control?.value !== matchingControl?.value){
                controls.get(matchingControlName)?.setErrors({matching : true});
                return {matching : true};
            }else{
                return null;
            }
        };
    }
}