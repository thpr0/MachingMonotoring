import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Machine } from '../_Models/Machine';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MachineService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getAllMachines(): Observable<Machine[]> {
    return this.http.get<Machine[]>(this.baseUrl + 'Machines');
   }

   getMachine(machineId): Observable<Machine> {
    return this.http.get<Machine>(this.baseUrl + 'Machine/' + machineId);
   }

   getTotalProduction(machineId): Observable<Machine> {
    return this.http.get<Machine>(this.baseUrl + 'Machine/TotalProduction/' + machineId);
   }

   deleteMachine(machineId): Observable<number> {
    return this.http.delete<number>(this.baseUrl + 'Machine/' + machineId);
   }
}
