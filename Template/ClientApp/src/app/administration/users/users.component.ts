import { Component, OnInit } from '@angular/core';
import { User } from './user.model';
import { RepositoryService } from '../../shared/services/repository.service' 

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
  public users: User[];

  constructor(private repository: RepositoryService) { }

  ngOnInit(): void {
    this.getCompanies();
  }

  public getCompanies = () => {
    const apiAddress: string = "api/users";
    this.repository.getData(apiAddress)
      .subscribe(res => {
        this.users = res as User[];
      })
  }

}
