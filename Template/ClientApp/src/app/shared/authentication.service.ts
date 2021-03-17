import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserAuthRequest } from '../interfaces/user-auth-request';
import { EnvironmentUrlService } from './environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private _http: HttpClient, private _envUrl: EnvironmentUrlService) { }

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }

  public loginUser = (route: string, body: UserAuthRequest) => {
    return this._http.post(this.createCompleteRoute(route, this._envUrl.urlAddress), body);
  }
}
