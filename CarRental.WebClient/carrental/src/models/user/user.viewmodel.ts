export class UserViewModel {
    id = 0;
    surname = '';
    name = '';
    birthDate = '';
    drivingLicenseNumber = '';
}

export class UserListViewModel {
    users: UserViewModel[] = [];
}
