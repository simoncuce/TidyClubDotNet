namespace TidyClubDotNet
{
    using TidyClubDotNet.Authentication;
    using TidyClubDotNet.Service;

    public class ServiceList
    {
        private readonly EventService eventService;

        private readonly CategoryService categoryService;

        private readonly ClubService clubService;

        private readonly CustomFieldService customFieldService;

        private readonly DepositService depositService;

        private readonly EmailService emailService;

        private readonly ExpenseService expenseService;

        private readonly GroupService groupService;

        private readonly InvoiceService invoiceService;

        private readonly MeetingService meetingService;

        private readonly TaskService taskService;

        private readonly TicketService ticketService;

        private readonly UserService userService;

        private readonly ContactService contactService;

        public ServiceList(string url, ResponseToken token)
        {
            this.eventService = new EventService(url, token);
            this.categoryService = new CategoryService(url, token);
            this.clubService = new ClubService(url, token);
            this.userService = new UserService(url, token);
            this.ticketService = new TicketService(url, token);
            this.meetingService = new MeetingService(url, token);
            this.invoiceService = new InvoiceService(url, token);
            this.groupService = new GroupService(url, token);
            this.expenseService = new ExpenseService(url, token);
            this.emailService = new EmailService(url, token);
            this.depositService = new DepositService(url, token);
            this.customFieldService = new CustomFieldService(url, token);
            this.taskService = new TaskService(url, token);
            this.contactService = new ContactService(url, token);
        }

        public EventService EventService
        {
            get
            {
                return this.eventService;
            }
        }

        public CategoryService CategoryService
        {
            get
            {
                return this.categoryService;
            }
        }

        public ClubService ClubService
        {
            get
            {
                return this.clubService;
            }
        }

        public ContactService ContactService
        {
            get
            {
                return this.contactService;
            }
        }

        public CustomFieldService CustomFieldService
        {
            get
            {
                return this.customFieldService;
            }
        }

        public DepositService DepositService
        {
            get
            {
                return this.depositService;
            }
        }

        public EmailService EmailService
        {
            get
            {
                return this.emailService;
            }
        }

        public ExpenseService ExpensesService
        {
            get
            {
                return this.expenseService;
            }
        }

        public GroupService GroupService
        {
            get
            {
                return this.groupService;
            }
        }

        public InvoiceService InvoiceService
        {
            get
            {
                return this.invoiceService;
            }
        }

        public MeetingService MeetingService
        {
            get
            {
                return this.meetingService;
            }
        }

        public TaskService TaskService
        {
            get
            {
                return this.taskService;
            }
        }

        public TicketService TicketService
        {
            get
            {
                return this.ticketService;
            }
        }

        public UserService UserService
        {
            get
            {
                return this.userService;
            }
        }
    }
}
