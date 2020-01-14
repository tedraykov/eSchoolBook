import {NbMenuItem} from "@nebular/theme";
import {Roles} from "../../../shared/enums/school-user-roles";

const superAdminMenu: NbMenuItem[] = [
    {
        title: 'Users', icon:"people-outline", expanded: true,
        children: [
            {title: 'Create school user', link: 'admin/create', icon: "person-add-outline"}
        ]
    }
];

const schoolAdminMenu: NbMenuItem[] = [
    {
        title: 'Users', group: true,
        children: [
            {title: 'create user', link: 'admin/create', icon: "person-add-outline"}
        ]
    }
];

const studentMenu: NbMenuItem[] = [
];

const teacherMenu: NbMenuItem[] = [
    {
        title: 'Subjects', icon: "book-outline", expanded: true,
        children: [
            {title: 'Curriculum', link: 'teacher/subject'}
        ]
    }
];

const principalMenu: NbMenuItem[] = [
];
const parentMenu: NbMenuItem[] = [
];

export const menuConfig: Map<string, NbMenuItem[]> = new Map([
    [Roles.SuperAdmin, superAdminMenu],
    [Roles.Admin, schoolAdminMenu],
    [Roles.Student, studentMenu],
    [Roles.Teacher, teacherMenu],
    [Roles.Principal, principalMenu],
    [Roles.Parent, parentMenu]
]);