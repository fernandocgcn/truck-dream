import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ModelService } from '../../services/model.service';
import { TruckService } from '../../services/truck.service';

@Component({
  selector: 'lst-truck',
  templateUrl: './lst-truck.component.html'
})
export class LstTruckComponent implements OnInit {
  public trucks: any[];
  private models: any[];

  constructor(private router: Router,
              private truckService: TruckService,
              private modelService: ModelService) { }

  public ngOnInit(): void {
    this.truckService.getAll()
      .subscribe(
        result => this.trucks = result,
        errorMessage => alert(errorMessage)
    );
    this.modelService.getAll()
      .subscribe(
        result => this.models = result,
        errorMessage => alert(errorMessage)
      );
  }

  public delete(truck: any): void {
    if (confirm(`Você realmente deseja excluir o Caminhão Nº '${truck.Id}'?`)) {
      this.truckService.delete(truck.Id)
        .subscribe(
          () => {
            this.trucks.splice(this.trucks.indexOf(truck), 1);
            alert(`Caminhão Nº '${truck.Id}' excluído com sucesso!`);
          },
          errorMessage => alert(errorMessage)
        );
    }
  }

  public add(): void {
    this.router.navigate(['frm-truck'], { state: { truck: { ProductionYear: (new Date()).getFullYear() }, models: this.models } });
  }

  public update(truck: any): void {
    this.router.navigate(['frm-truck'], { state: { truck, models: this.models } });
  }
}
