export class UserViewModel {
    id: number = 0;
    surname: string = "";
    name: string = "";
    birthDate: string = "";
    drivingLicenseNumber: string = "";
}

export class UserListViewModel {
    users: UserViewModel[] = [];
}