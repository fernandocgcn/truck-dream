import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { TruckService } from '../../services/truck.service';
 
@Component({
  selector: 'frm-truck',
  templateUrl: './frm-truck.component.html',
  styleUrls: ['./frm-truck.component.css']
})
export class FrmTruckComponent implements OnInit {
  public readonly truck: any;
  public readonly models: any[];

  public form: FormGroup;

  constructor(private router: Router,
              private formBuilder: FormBuilder,
              private truckService: TruckService) {
    const navigation = this.router.getCurrentNavigation();
    this.truck = navigation.extras.state.truck;
    this.models = navigation.extras.state.models;
  }

  public ngOnInit(): void {
    this.form = this.formBuilder.group({
      ProductionYear: [this.truck.ProductionYear, Validators.required],
      ModelYear: [this.truck.ModelYear, [Validators.required,
        Validators.min(this.truck.ProductionYear), Validators.max(this.truck.ProductionYear+1)]],
      Color: [this.truck.Color],
      Horsepower: [this.truck.Horsepower],
      Mileage: [this.truck.Mileage],
      Model: [this.truck.Model, [Validators.required, acronymValidator(['FH','FM'])]]
    });
  }

  public onSubmit(): void {
    if (this.form.valid) {

      this.form.value.Id = this.truck.Id;
      if (this.form.value.Id) {
        this.truckService.update(this.form.value)
          .subscribe(() => {
            alert('Caminhão atualizado com sucesso!');
            this.router.navigate(['']);
          },
            errorMessage => alert(errorMessage)
          );
      }
      else {
        this.truckService.insert(this.form.value)
          .subscribe(() => {
              alert('Caminhão inserido com sucesso!');
              this.router.navigate(['']);
            },
              errorMessage => alert(errorMessage)
          );
      }

    } else {

      Object.keys(this.form.controls).forEach(controlName => {
        this.form.get(controlName).markAllAsTouched();
      });

    }
  }

  public onReset(): void {
    const formGroup = this.form as FormGroup;
    formGroup.reset();
    this.form.get('ProductionYear').setValue(this.truck.ProductionYear);
  }

  public invalid(control: FormControl): boolean {
    return !control.valid && control.touched;
  }

  public compareFn(c1: any, c2: any): boolean {
    return c1 && c2 ? c1.Id === c2.Id : c1 === c2;
  }

}

export function acronymValidator(acronyms: string[]): ValidatorFn {
  return (control: FormControl): { [key: string]: any } | null => {
    const notFound = control.value != null && acronyms.indexOf(control.value.Acronym) < 0;
    return notFound ? { acronym: control.value.Acronym } : null;
  };
}
