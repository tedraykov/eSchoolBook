import {NbMenuItem} from "@nebular/theme";
import {Roles} from "../../../shared/enums/school-user-roles";

const superAdminMenu: NbMenuItem[] = [
    {
        title: 'Users', icon:"people-outline", expanded: true,
        children: [
            {title: 'Create school user', link: 'admin/user/create', icon: 'person-add-outline'}
        ],
    },
    {
        title: 'Schools', icon: 'home-outline', expanded: true,
        children: [
            {title: 'Add new school', link: 'admin/school/add'}
        ]
    }
];

const schoolAdminMenu: NbMenuItem[] = [
    {
        title: 'Users', group: true,
        children: [
            {title: 'create user', link: 'admin/user/create', icon: "person-add-outline"}
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
    {
        title: 'Dashboard', icon: "trending-up-outline", expanded: true,
        children: [
            {title: 'School Analytics', link: 'principal/statistics'}
        ]
    },
    {
        title: 'School Archive', icon: "archive-outline", expanded: true,
        children: [
            {title: 'Teachers Data', link: 'principal/teachers'},
            {title: 'Students Data', link: 'principal/students'},
            {title: 'Parents Data', link: 'principal/parents'}
        ]
    }

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
