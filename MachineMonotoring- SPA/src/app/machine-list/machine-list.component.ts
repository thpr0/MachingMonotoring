import { Component, OnInit } from '@angular/core';
import { Machine } from '../_Models/Machine';
import { MachineService } from '../machine.service';

@Component({
  selector: 'app-machine-list',
  templateUrl: './machine-list.component.html',
  styleUrls: ['./machine-list.component.css']
})
export class MachineListComponent implements OnInit {
  machines: Machine[];
  constructor(private machineService: MachineService) { }

  ngOnInit(): void {
    this.machineService.getAllMachines().subscribe((res: Machine[]) => {
      this.machines = res;
    });
  }


  deleteMachine(id: number) {
    if (confirm('Do you really want to remove this machine?')) {
      this.machineService.deleteMachine(id).subscribe((res: number) => {
          this.machines = this.machines.filter(item => item.machineId !== id);
          alert('Machine deleted Successfuly');
      });
    }
  }

}
