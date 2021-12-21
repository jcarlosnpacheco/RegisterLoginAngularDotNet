import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

import { RegisterLogin } from '../models/register-login';
import { ResponseCreateRegisterLogin } from '../models/response-create-register-login';

@Injectable({
  providedIn: 'root',
})
export class RegisterLoginService {
  private urlRegister = `${environment.apiUrl}/RegisterLogin`;

  constructor(private http: HttpClient) {}

  delete(id: number): Observable<any> {
    return this.http.delete(`${this.urlRegister}/${id}`);
  }

  getAllByRegisterName(registerLoginName: string): Observable<RegisterLogin[]> {
    return this.http.get<RegisterLogin[]>(
      `${this.urlRegister}/GetRegisterLoginByName/${registerLoginName}`
    );
  }

  getById(id: number): Observable<RegisterLogin[]> {
    return this.http.get<RegisterLogin[]>(
      `${this.urlRegister}/GetRegisterLoginById/${id}`
    );
  }

  getAll(): Observable<RegisterLogin[]> {
    return this.http.get<RegisterLogin[]>(
      `${this.urlRegister}/GetAllRegisterLogin`
    );
  }

  create(
    registerLogin: RegisterLogin
  ): Observable<ResponseCreateRegisterLogin> {
    return this.http.post<ResponseCreateRegisterLogin>(
      this.urlRegister,
      registerLogin
    );
  }

  update(servicoTramo: RegisterLogin): Observable<ResponseCreateRegisterLogin> {
    return this.http.put<ResponseCreateRegisterLogin>(
      this.urlRegister,
      servicoTramo
    );
  }
}
