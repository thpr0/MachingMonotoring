import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Machine } from '../_Models/Machine';
import { MachineService } from '../machine.service';

@Component({
  selector: 'app-machine-details',
  templateUrl: './machine-details.component.html',
  styleUrls: ['./machine-details.component.css']
})
export class MachineDetailsComponent implements OnInit {
  machineId: number;
  machine: Machine;
  interval: any;
  constructor(private route: ActivatedRoute, private http: HttpClient, private machineService: MachineService) { }

  ngOnInit(): void {
    this.route.params.subscribe(data => {
      this.machineId = data.id;
    });
    this.machineService.getMachine(this.machineId).subscribe((res: Machine) => {
      this.machine = res;
    });
    this.getTotalProduction();
    this.interval = setInterval(() => {
      this.getTotalProduction();
   }, 5000);
  }

  getTotalProduction(): void {
    this.machineService.getTotalProduction(this.machineId).subscribe((res: Machine) => {
      this.machine.totalProduction = res.totalProduction;
    });
  }

}
