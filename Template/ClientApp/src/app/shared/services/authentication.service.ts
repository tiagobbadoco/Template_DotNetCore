import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserAuthRequest } from '../../interfaces/users/user-auth-request';
import { EnvironmentUrlService } from './environment-url.service';
import { Subject } from 'rxjs';
import { UserRegisterRequest } from '../../interfaces/users/user-register-request';
import { UserRegisterResponse } from '../../interfaces/users/user-register-response';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private _authChangeSub = new Subject<boolean>()
  public authChanged = this._authChangeSub.asObservable();

  constructor(private _http: HttpClient, private _envUrl: EnvironmentUrlService) { }

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }

  public sendAuthStateChangeNotification = (isAuthenticated: boolean) => {
    this._authChangeSub.next(isAuthenticated);
  }

  public registerUser = (route: string, body: UserRegisterRequest) => {
    return this._http.post<UserRegisterResponse>(this.createCompleteRoute(route, this._envUrl.urlAddress), body);
  }

  public loginUser = (route: string, body: UserAuthRequest) => {
    return this._http.post(this.createCompleteRoute(route, this._envUrl.urlAddress), body);
  }

  public logout = () => {
    localStorage.removeItem("token");
    this.sendAuthStateChangeNotification(false);
  }
}
