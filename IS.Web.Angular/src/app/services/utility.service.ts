import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { GlobalConstants } from '../common/globalconstants.model';
import { Department } from '../models/department.model';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class UtilityService {

  constructor(private api:ApiService) { }
  
}
