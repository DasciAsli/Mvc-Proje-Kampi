using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message
    {

        [Key]
        public int MessageId { get; set; }

        [StringLength(50)]
        public string SenderMail { get; set; }

        [StringLength(50)]
        public string Receiver { get; set; }

        [StringLength(100)]
        public string Subject { get; set; }

        [StringLength(150)]
        public string MessageContent { get; set; }

        public bool ReadStatus { get; set; }
        public bool isDraft { get; set; }
        public DateTime MessageDate { get; set; }
    }
}
